using System.Collections.Generic;
using Bogus;
using Homework_REST.Constants.Message;
using Homework_REST.Factories;
using Homework_REST.Models.ProjectModel;
using Homework_REST.Utils;
using Newtonsoft.Json;

namespace Homework_REST.Mock
{
    public class ProjectMocks
    {
        public static IEnumerable<object[]> IncorrectValues()
        {
            var moreThanMaxLength = ProjectFactory.GetProjectModel();
            moreThanMaxLength.Name = RandomUtils.GenerateString(
                Constants.ValidationConstants.Constants.RequestProjectModel.NotesMaxLength + 1);
            
            var serializedProject = NewtonsoftJsonSerializer.Serialize(moreThanMaxLength);
            const string typeOfError = ErrorMessage.MoreThanMaxValue;

            var missingValue = ProjectFactory.GetProjectModel();
            missingValue.Name = null;

            var serializedNullNameProject = NewtonsoftJsonSerializer.Serialize(missingValue);
            const string typeError = ErrorMessage.RequiredField;

            return new List<object[]>
            {
                new object[]
                {
                    serializedProject,
                    typeOfError
                }, 
                new object[]
                {
                    serializedNullNameProject,
                    typeError
                }
            };
        }

        public static IEnumerable<object[]> IncorrectId()
        {
            const int incorrectId = 3;
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