using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace GameDrones.Tests.AutoFixture
{
    /// <summary>
    /// Auto mocking attributes wrapping the functionality of AutoFixture into attributes.
    /// </summary>
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="AutoMoqDataAttribute"/> class.
        /// </summary>
        public AutoMoqDataAttribute()
            : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}