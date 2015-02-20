// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNet.Mvc.Razor
{
    /// <summary>
    /// Represents the result of compilation that does not come from the <see cref="ICompilerCache" />.
    /// </summary>
    public class UncachedCompilationResult : CompilationResult
    {
        /// <summary>
        /// Creates a new instance of <see cref="UncachedCompilationResult"/> that represents a success in compilation.
        /// </summary>
        /// <param name="type">The compiled type.</param>
        /// <param name="compiledContent">The generated C# content that was compiled.</param>
        public UncachedCompilationResult([NotNull] Type type, string compiledContent)
            : base(type)
        {
            CompiledContent = compiledContent;
        }

        /// <summary>
        /// Gets the generated C# content that was compiled.
        /// </summary>
        public string CompiledContent { get; }
    }
}