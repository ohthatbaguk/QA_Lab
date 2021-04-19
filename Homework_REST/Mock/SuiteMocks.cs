using System.Collections.Generic;
using Homework_REST.Constants.Message;
using Homework_REST.Factories;
using Homework_REST.Utils;

namespace Homework_REST.Mock
{
    public class SuiteMocks
    {
        public static IEnumerable<object[]> IncorrectValuesForUpdateSuite()
        {
            var moreThanMaxLength = SuiteFactory.GetSuiteModel();
            moreThanMaxLength.Name = RandomUtils.GenerateString(
                Constants.ValidationConstants.Constants.RequestProjectModel.NotesMaxLength + 1);
            
            var serializedSuite = NewtonsoftJsonSerializer.Serialize(moreThanMaxLength);
            const string typeOfError = ErrorMessage.MoreThanMaxValue;
            
            
            return new List<object[]>
            {
                new object[]
                {
                    serializedSuite,
                    typeOfError
                }
            
            };
        }
        
        public static IEnumerable<object[]> IncorrectValuesForAddSuite()
        {
            var moreThanMaxLength = SuiteFactory.GetSuiteModel();
            moreThanMaxLength.Name = RandomUtils.GenerateString(
                Constants.ValidationConstants.Constants.RequestProjectModel.NotesMaxLength + 1);
            
            var serializedSuite = NewtonsoftJsonSerializer.Serialize(moreThanMaxLength);
            const string typeOfError = ErrorMessage.MoreThanMaxValue;

            var nullNameSuite = SuiteFactory.GetSuiteModel();
            nullNameSuite.Name = null;

            var serializedNullNameSuite = NewtonsoftJsonSerializer.Serialize(nullNameSuite);
            const string typeError = ErrorMessage.RequiredField;
            
            
            return new List<object[]>
            {
                new object[]
                {
                    serializedSuite,
                    typeOfError
                },
            
                new object[]
                {
                    serializedNullNameSuite,
                    typeError
                }
            };
        }
    }
}