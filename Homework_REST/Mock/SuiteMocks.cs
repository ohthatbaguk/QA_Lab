using System.Collections.Generic;
using Bogus;
using Homework_REST.Models.SuiteModel;
using Homework_REST.Utils;

namespace Homework_REST.Mock
{
    public class SuiteMocks
    {
        public static IEnumerable<object[]> SuiteMissingValues()
        {
            var missingRequiredName = new RequestSuiteModel
            {
                Description = new Faker().Lorem.Sentence(3)
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
                Name = RandomUtils.GenerateString(
                    Constants.ValidationConstants.Constants.RequestProjectModel.NotesMaxLength + 1),
                Description = new Faker().Lorem.Sentence(3)
            };
            
            return new List<object[]>
            {
                new object[]
                {
                    missingRequiredName
                }
            };
        }
        
        public static IEnumerable<object[]> IncorrectSuiteId()
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