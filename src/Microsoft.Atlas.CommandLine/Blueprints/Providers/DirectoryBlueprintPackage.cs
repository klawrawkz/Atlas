// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Atlas.CommandLine.Abstractions;

namespace Microsoft.Atlas.CommandLine.Blueprints.Providers
{
    public class DirectoryBlueprintPackage : IBlueprintPackage
    {
        private readonly IFileSystem _fileSystem;
        private readonly string _directoryPath;

        public DirectoryBlueprintPackage(IFileSystem fileSystem, string directoryPath)
        {
            _fileSystem = fileSystem;
            _directoryPath = directoryPath;
        }

        public string Location => _directoryPath;

        public bool Exists(string path) => _fileSystem.FileExists(ActualPath(path));

        public IEnumerable<string> GetGeneratedPaths() => Enumerable.Empty<string>();

        public TextReader OpenText(string path) => _fileSystem.OpenText(ActualPath(path));

        private string ActualPath(string path) => _fileSystem.PathCombine(_directoryPath, path);
    }
}
