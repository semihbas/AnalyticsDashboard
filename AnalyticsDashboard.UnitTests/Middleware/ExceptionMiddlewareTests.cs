using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AnalyticsDashboard.Api.UnitTests.Middleware
{
    [TestClass]
    public class ExceptionMiddlewareTests
    {

        private readonly ILoggerFactory loggerFactory;

        public ExceptionMiddlewareTests()
        {
            loggerFactory = new LoggerFactory();
        }

        [TestMethod]
        public async Task InvokeAsync_NoExceptionThrownInsideMiddleware_ContextResponseNotModifiedAsync()
        {
            //arrange
            var middleWare = new ExceptionMiddleware(next: async (innerHttpContext) =>
            {
                await Task.Run(() =>
                {
                    return HttpStatusCode.OK;
                });
            }, loggerFactory);
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //act
            await middleWare.InvokeAsync(context);

            //assert
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var body = reader.ReadToEnd();
            Assert.AreEqual("", body);
        }

        [TestMethod]
        public async Task InvokeAsync_InternalServerErrorThrownInsideMiddleware_ContextResponseModifiedAsync()
        {
            //arrange
            string expectedOutput = "{\"Message\":\"Internal server error\"}";
            var middleWare = new ExceptionMiddleware(next: async (innerHttpContext) =>
            {
                await Task.Run(() =>
                {
                    throw new Exception();
                });
            }, loggerFactory);
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //act
            await middleWare.InvokeAsync(context);

            //assert
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var body = reader.ReadToEnd();
            Assert.AreEqual(expectedOutput, body);
        }

        [TestMethod]
        public async Task InvokeAsync_ValidationExceptionThrownInsideMiddleware_ContextResponseModifiedAsync()
        {
            //arrange
            string expectedOutput = "{\"Message\":\"Bad Request\"}";
            var middleWare = new ExceptionMiddleware(next: async (innerHttpContext) =>
            {
                await Task.Run(() =>
                {
                    throw new ValidationException("Bad Request");
                });
            }, loggerFactory);
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //act
            await middleWare.InvokeAsync(context);

            //assert
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var body = reader.ReadToEnd();
            Assert.AreEqual(expectedOutput, body);
        }

        [TestMethod]
        public async Task InvokeAsync_UnauthorizedAccessExceptionThrownInsideMiddleware_ContextResponseModifiedAsync()
        {
            //arrange
            string expectedOutput = "{\"Message\":\"You have no access\"}";
            var middleWare = new ExceptionMiddleware(next: async (innerHttpContext) =>
            {
                await Task.Run(() =>
                {
                    throw new UnauthorizedAccessException();
                });
            }, loggerFactory);
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //act
            await middleWare.InvokeAsync(context);

            //assert
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var body = reader.ReadToEnd();
            Assert.AreEqual(expectedOutput, body);
        }

    }
}
