using System.Web.Mvc;
using FluentAssertions;

namespace ActiveRecord.CheckOutWeb.Tests
{
    internal static class Extensions
    {
        internal static T ShouldHaveModel<T>(this ViewResult result) where T : class
        {
            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();

            var model = result.Model as T;
            model.Should().NotBeNull();

            return model;
        }
    }
}
