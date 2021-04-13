using System.Collections.Generic;
using Homework_REST.Models;
using Homework_REST.Utils;
using Homework_REST.ValidationConstants;

namespace Homework_REST
{
    public class Mocks
    {
        public static IEnumerable<object[]> ProjectMissingValues()
        {
            var missingRequiredName = new RequestProjectModel
            {
                Announcement = "This is project",
                ShowAnnouncement = true
            };
            
            return new List<object[]>
            {
                new object[]
                {
                    missingRequiredName
                },
            };
        }
        
        public static IEnumerable<object[]> SuiteMissingValues()
        {
            var missingRequiredName = new RequestSuiteModel()
            {
                Description = "Na na na"
            };
            
            return new List<object[]>
            {
                new object[]
                {
                    missingRequiredName
                },
            };
        } 
        
        public static IEnumerable<object[]> MoreThanMaxLengthValues()
        {
            var missingRequiredName = new RequestSuiteModel
            {
                Name = RandomUtils.GenerateString(Constants.Model.NotesMaxLength + 1),
                Description = "Na na na"
            };
            
            return new List<object[]>
            {
                new object[]
                {
                    missingRequiredName
                },
            };
        } 
    }
}