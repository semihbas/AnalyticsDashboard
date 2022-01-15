using System;
using System.Net;

namespace AnalyticsDashboard.Api.Middleware
{
    public class ResponseException : Exception
    {
        public int StatusCode { get; private set; }

        public ResponseException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = (int)statusCode;
        }

        public ResponseException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
