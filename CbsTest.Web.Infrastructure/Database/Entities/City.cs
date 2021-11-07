using System;

namespace CbsTest.Web.Infrastructure.Database.Entities
{
    public record City(Guid Id, string Name, int Population, DateOnly FoundationDate);
}
