﻿using System;
using AnalyticsDashboard.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalyticsDashboard.Data.Configuration
{
    public class TradingModelConfiguration : IEntityTypeConfiguration<TradingModel>
    {
        public void Configure(EntityTypeBuilder<TradingModel> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
