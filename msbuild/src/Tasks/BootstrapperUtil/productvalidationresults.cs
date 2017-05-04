﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Xml;

namespace Microsoft.Build.Tasks.Deployment.Bootstrapper
{
    /// <summary>
    /// Handles and stores xml validation events for a product, and contains the XmlValidationResults of a package.
    /// </summary>
    internal sealed class ProductValidationResults : XmlValidationResults
    {
        private Hashtable _packageValidationResults;

        public ProductValidationResults(string filePath) : base(filePath)
        {
            _packageValidationResults = new Hashtable();
        }

        /// <summary>
        /// Adds the validation results of a package of the specified culture into the ProductValidationResults.
        /// </summary>
        /// <param name="culture">The culture of the XmlValidationResults to add.</param>
        /// <param name="results">The vaue of the results to add.</param>
        public void AddPackageResults(string culture, XmlValidationResults results)
        {
            if (!_packageValidationResults.Contains(culture))
            {
                _packageValidationResults.Add(culture, results);
            }
            else
            {
                System.Diagnostics.Debug.Fail("Validation results have already been added for culture '{0}'", culture);
            }
        }

        /// <summary>
        /// Gets the XmlValidationResults for the specified culture.
        /// </summary>
        /// <param name="culture">The culture of the XmlValidationResults to get.</param>
        /// <returns>The XmlValidationResults associated with the specified culture.</returns>
        public XmlValidationResults PackageResults(string culture)
        {
            return (XmlValidationResults)_packageValidationResults[culture];
        }
    }
}
