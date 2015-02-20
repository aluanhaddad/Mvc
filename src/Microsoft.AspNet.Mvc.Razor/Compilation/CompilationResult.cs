// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Framework.Runtime;

namespace Microsoft.AspNet.Mvc.Razor
{
    /// <summary>
    /// Represents the result of compilation.
    /// </summary>
    public class CompilationResult
    {
        /// <summary>
        /// Creates a new instance of <see cref="CompilationResult"/> that represents a success in compilation.
        /// </summary>
        /// <param name="type">The compiled type.</param>
        public CompilationResult([NotNull] Type compiledType)
        {
            CompiledType = compiledType;
        }

        /// <summary>
        /// Creates a <see cref="CompilationResult"/> that represents a failure in compilation.
        /// </summary>
        /// <param name="compilationFailure">The <see cref="ICompilationFailure"/> produced from parsing or
        /// compiling the Razor file.</param>
        public CompilationResult([NotNull] ICompilationFailure compilationFailure)
        {
            CompilationFailure = compilationFailure;
        }

        /// <summary>
        /// Gets the type produced as a result of compilation.
        /// </summary>
        /// <remarks>This property is null when compilation fails.</remarks>
        public Type CompiledType { get; }

        /// <summary>
        /// Gets the type produced as a result of compilation.
        /// </summary>
        /// <remarks>This property is null when compilation succeeds.</remarks>
        public ICompilationFailure CompilationFailure { get; }

        /// <summary>
        /// Throws an exception if compilation has failed.
        /// </summary>
        /// <returns>The current <see cref="CompilationResult"/> instance.</returns>
        public CompilationResult EnsureSuccessful()
        {
            if (CompilationFailure != null)
            {
                throw new CompilationFailedException(CompilationFailure);
            }

            return this;
        }
    }
}
