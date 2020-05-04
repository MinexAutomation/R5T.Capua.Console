﻿using System;

using R5T.Capua.Source;
using R5T.Macommania;


namespace ΩMaintenance.Services
{
    public class SolutionDirectoryPathProvider : ISolutionDirectoryPathProvider
    {
        private IExecutableFileDirectoryPathProvider ExecutableFileDirectoryPathProvider { get; }
        private ISolutionAndProjectFileSystemConventions SolutionAndProjectFileSystemConventions { get; }


        public SolutionDirectoryPathProvider(
            IExecutableFileDirectoryPathProvider executableFileDirectoryPathProvider,
            ISolutionAndProjectFileSystemConventions solutionAndProjectFileSystemConventions)
        {
            this.ExecutableFileDirectoryPathProvider = executableFileDirectoryPathProvider;
            this.SolutionAndProjectFileSystemConventions = solutionAndProjectFileSystemConventions;
        }

        public string GetSolutionDirectoryPath()
        {
            var executableFileDirectoryPath = this.ExecutableFileDirectoryPathProvider.GetExecutableFileDirectoryPath();

            var solutionDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetSolutionDirectoryPathFromExecutableFileDirectoryPath(executableFileDirectoryPath);
            return solutionDirectoryPath;
        }
    }
}
