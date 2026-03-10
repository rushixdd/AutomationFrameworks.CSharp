// <copyright file="TestContextHolder.cs" company="rushixdd">
// Copyright (c) rushixdd. All rights reserved.
// </copyright>

namespace Framework.Context
{
    using Framework.Configuration;
    using OpenQA.Selenium;

    /// <summary>
    /// Provides a container for test context settings and manages the lifecycle of web drivers used in automated UI
    /// tests.
    /// </summary>
    /// <remarks>The TestContextHolder class is responsible for initializing web drivers based on the
    /// specified test settings and ensuring proper disposal of driver resources. This helps prevent resource leaks and
    /// supports consistent test execution. Use this class to centralize driver management when running tests that
    /// require browser automation.</remarks>
    public class TestContextHolder
    {
        public TestSettings Settings { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestContextHolder"/> class.
        /// </summary>
        /// <param name="settings">Test Settings.</param>
        public TestContextHolder(TestSettings settings)
        {
            this.Settings = settings;
        }

        /// <summary>
        /// Initializes a new web driver instance configured for the browser specified in the current settings.
        /// </summary>
        /// <remarks>This method uses the <see cref="Drivers.DriverFactory"/> to create the driver. Ensure
        /// that the browser defined in <see cref="Settings.Browser"/> is supported by the driver factory. The returned
        /// driver must be disposed when no longer needed to release browser resources.</remarks>
        /// <returns>An <see cref="IWebDriver"/> instance that enables automated interaction with the selected browser.</returns>
        public IWebDriver InitializeDriver() {
            var factory = new Drivers.DriverFactory();
            return factory.Create(Settings.Browser);
        }

        /// <summary>
        /// Releases all resources used by the specified web driver and terminates any associated browser processes.
        /// </summary>
        /// <remarks>This method calls both the Quit and Dispose methods on the driver to ensure that all
        /// browser sessions and related resources are fully released. It is important to invoke this method when the
        /// driver is no longer needed to prevent resource leaks.</remarks>
        /// <param name="driver">The web driver instance to be disposed. This parameter must not be null and should be properly initialized
        /// before calling this method.</param>
        public void Dispose(IWebDriver driver)
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
