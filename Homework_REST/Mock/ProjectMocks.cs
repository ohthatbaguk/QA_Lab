using System.Collections.Generic;
using Bogus;
using Homework_REST.Models.ProjectModel;
using Homework_REST.Utils;

namespace Homework_REST.Mock
{
    public class ProjectMocks
    {
        public static IEnumerable<object[]> ProjectMissingValues()
        {
            var missingRequiredName = new RequestProjectModel
            {
                Announcement = new Faker().Lorem.Sentence(3),
                ShowAnnouncement = true
            };
            
            return new List<object[]>
            {
                new object[]
                {
                    missingRequiredName
                }
            };
        }
        
        public static IEnumerable<object[]> ProjectIncorrectValues()
        {
            var missingRequiredName = new RequestProjectModel
            {
                Name = RandomUtils.GenerateString(
                    Constants.ValidationConstants.Constants.RequestProjectModel.NotesMaxLength + 1),
                Announcement = new Faker().Lorem.Sentence(3),
                ShowAnnouncement = true
            };
            
            return new List<object[]>
            {
                new object[]
                {
                    missingRequiredName
                }
            };
        }
        
        public static IEnumerable<object[]> IncorrectProjectId()
        {
            const int incorrectId = 000;
            const string missingId = null;
            
            return new List<object[]>
            {
                new object[]
                {
                    incorrectId
                },
                
                new object[]
                {
                    missingId
                }
            };
        }
    }
}