using System;
using System.Globalization;
using System.Linq;
using StubGenerator.Core;
using StubGenerator.Test.Models;
using Xunit;

namespace StubGenerator.Test
{
    public class StubManagerTests
    {
        private readonly StubManager _stubManager;
        public StubManagerTests()
        {
            var stubManagerOptions = new StubManagerOptions { AutoGenerateUnknown = true, AutoResolveByNaming = true };
            _stubManager = new StubManager(stubManagerOptions);
        }

        [Fact(DisplayName = "Mapping Check By Naming Default Conventions")]
        public void Naming_Mapping_Check()
        {
            var stubDto = _stubManager.CreateNew<PersonDto>();
            Assert.NotNull(stubDto.FirstName);
            Assert.NotNull(stubDto.LastName);
            Assert.NotNull(stubDto.Email);
        }


        [Fact(DisplayName = "Mapping Check By Naming Default Conventions List Of")]
        public void Naming_Mapping_Check_List_Of()
        {
            var listOfDto = _stubManager.CreateListOfSize<PersonDto>(10);
            var stubDto = listOfDto.First();
            Assert.NotNull(stubDto.FirstName);
            Assert.NotNull(stubDto.LastName);
            Assert.NotNull(stubDto.Email);
            Assert.Equal(10, listOfDto.Count);
        }

        [Fact(DisplayName = "Mapping Check By Naming Default Conventions Big List")]
        public void Naming_Mapping_Check_Big_List()
        {
            var listOfDto = _stubManager.CreateListOfSize<PersonDto>(100);
            var stubDto = listOfDto.First();
            Assert.NotNull(stubDto.FirstName);
            Assert.NotNull(stubDto.LastName);
            Assert.NotNull(stubDto.Email);
            Assert.Equal(100, listOfDto.Count);
        }


        [Fact(DisplayName = "Mapping Check By Naming Default Conventions DE Culture")]
        public void Naming_Mapping_Check_Culture()
        {
            var deCulture = new CultureInfo("de-DE");
            System.Threading.Thread.CurrentThread.CurrentCulture = deCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = deCulture;
            var stubDto = _stubManager.CreateNew<PersonDto>();
            Assert.NotNull(stubDto.FirstName);
            Assert.NotNull(stubDto.LastName);
            Assert.NotNull(stubDto.Email);
        }

        [Fact(DisplayName = "Should Generate Data For Guid Type")]
        public void Should_Generate_Data_For_Guid_Type()
        {
            var generatedStubData = _stubManager.CreateNew<InnerComplexType>();
            Assert.NotEqual(Guid.Empty, generatedStubData.GuidProperty);
            Assert.True(Guid.TryParse(generatedStubData.GuidProperty.ToString(), out _));
        }


        [Fact(DisplayName = "Should Generate Data For Byte Type In Range")]
        public void Should_Generate_Data_For_Byte_Type_In_Range()
        {
            var generatedStubData = _stubManager.CreateNew<ModelOfType<Byte>>();
            Assert.NotNull(generatedStubData);
            Assert.InRange(generatedStubData.Value, byte.MinValue, byte.MaxValue);
        }

        [Fact(DisplayName = "Should Generate Data For Single Type In Range")]
        public void Should_Generate_Data_For_Single_Type_In_Range()
        {
            var generatedStubData = _stubManager.CreateNew<ModelOfType<Single>>();
            Assert.NotNull(generatedStubData);
            Assert.InRange(generatedStubData.Value, Single.MinValue, Single.MaxValue);
        }


        [Fact(DisplayName = "Should Generate Data For Int16 Type In Range")]
        public void Should_Generate_Data_For_Int16_Type_In_Range()
        {
            var generatedStubData = _stubManager.CreateNew<ModelOfType<Int16>>();
            Assert.NotNull(generatedStubData);
            Assert.InRange(generatedStubData.Value, Int16.MinValue, Int16.MaxValue);
        }


        [Fact(DisplayName = "Should Generate Data For Int32 Type In Range")]
        public void Should_Generate_Data_For_Int32_Type_In_Range()
        {
            var generatedStubData = _stubManager.CreateNew<ModelOfType<Int32>>();
            Assert.NotNull(generatedStubData);
            Assert.InRange(generatedStubData.Value, Int32.MinValue, Int32.MaxValue);
        }

        [Fact(DisplayName = "Should Generate Data For Int64 Type In Range")]
        public void Should_Generate_Data_For_Int64_Type_In_Range()
        {
            var generatedStubData = _stubManager.CreateNew<ModelOfType<Int64>>();
            Assert.NotNull(generatedStubData);
            Assert.InRange(generatedStubData.Value, Int64.MinValue, Int64.MaxValue);
        }

        [Fact(DisplayName = "Should Generate Data For Double Type In Range")]
        public void Should_Generate_Data_For_Double_Type_In_Range()
        {
            var generatedStubData = _stubManager.CreateNew<ModelOfType<Double>>();
            Assert.NotNull(generatedStubData);
            Assert.InRange(generatedStubData.Value, Double.MinValue, Double.MaxValue);
        }


        [Fact(DisplayName = "Should Generate Data For Decimal Type In Range")]
        public void Should_Generate_Data_For_Decimal_Type_In_Range()
        {
            var generatedStubData = _stubManager.CreateNew<ModelOfType<Decimal>>();
            Assert.NotNull(generatedStubData);
            Assert.InRange(generatedStubData.Value, Decimal.MinValue, Decimal.MaxValue);
        }

        [Fact(DisplayName = "Should Generate Data For UInt16 Type In Range")]
        public void Should_Generate_Data_For_UInt16_Type_In_Range()
        {
            var generatedStubData = _stubManager.CreateNew<ModelOfType<UInt16>>();
            Assert.NotNull(generatedStubData);
            Assert.InRange(generatedStubData.Value, UInt16.MinValue, UInt16.MaxValue);
        }

        [Fact(DisplayName = "Should Generate Data For UInt32 Type In Range")]
        public void Should_Generate_Data_For_UInt32_Type_In_Range()
        {
            var generatedStubData = _stubManager.CreateNew<ModelOfType<UInt32>>();
            Assert.NotNull(generatedStubData);
            Assert.InRange(generatedStubData.Value, UInt32.MinValue, UInt32.MaxValue);
        }

        [Fact(DisplayName = "Should Generate Data For UInt64 Type In Range")]
        public void Should_Generate_Data_For_UInt64_Type_In_Range()
        {
            var generatedStubData = _stubManager.CreateNew<ModelOfType<UInt64>>();
            Assert.NotNull(generatedStubData);
            Assert.InRange(generatedStubData.Value, UInt64.MinValue, UInt64.MaxValue);
        }

        [Fact(DisplayName = "Should Generate Data For Char Type")]
        public void Should_Generate_Data_For_Chard_Type()
        {
            var generatedStubData = _stubManager.CreateNew<ModelWithComplexTypeProperty>();
            Assert.NotEqual(default(char), generatedStubData.PrefixChar);
        }

        [Fact(DisplayName = "Should Generate Data For DateTime Type")]
        public void Should_Generate_Data_For_DateTime_Type()
        {
            var generatedStubData = _stubManager.CreateNew<InnerComplexType>();
            Assert.IsType<DateTime>(generatedStubData.DateTimeProperty);
            Assert.NotEqual(default(DateTime), generatedStubData.DateTimeProperty);
        }

        [Fact(DisplayName = "Should Generate Data For Decimal Type")]
        public void Should_Generate_Data_For_Decimal_Type()
        {
            var generatedStubData = _stubManager.CreateNew<InnerComplexType>();
            Assert.IsType<decimal>(generatedStubData.DecimalProperty);
            Assert.NotEqual(default(decimal), generatedStubData.DecimalProperty);
        }

        [Fact(DisplayName = "Should Generate Data For Double Type")]
        public void Should_Generate_Data_For_Double_Type()
        {
            var generatedStubData = _stubManager.CreateNew<InnerComplexType>();
            Assert.IsType<double>(generatedStubData.DoubleProperty);
            Assert.NotEqual(default(double), generatedStubData.DoubleProperty);
        }

        [Fact(DisplayName = "Should Generate Data For Enum Type")]
        public void Should_Generate_Data_For_Enum_Type()
        {
            var generatedStubData = _stubManager.CreateNew<InnerComplexType>();
            var enumValues = Enum.GetValues(typeof(EnTestEnum)).Cast<EnTestEnum>().ToList();
            Assert.Contains(generatedStubData.EnumProperty, enumValues);
        }

        [Fact(DisplayName = "Should Generate Data for Nullable Type")]
        public void Should_Generate_Data_For_Nullable_Type()
        {
            var generatedStubData = _stubManager.CreateNew<InnerComplexType>();
            Assert.NotNull(generatedStubData.NullableIntegerProperty);
            Assert.NotNull(generatedStubData.NullableIntegerProperty2);
        }

        [Fact(DisplayName = "Should Generate Data For Complex Type Properties")]
        public void Should_Generate_Data_For_Complex_Type_Properties()
        {
            var generatedStubData = _stubManager.CreateNew<ModelWithComplexTypeProperty>();
            Assert.NotNull(generatedStubData.ComplexType);
            Assert.True(Guid.NewGuid() != generatedStubData.ComplexType.GuidProperty);
            Assert.True(default(decimal) != generatedStubData.ComplexType.DecimalProperty);
            Assert.True(default(double) != generatedStubData.ComplexType.DoubleProperty);
            Assert.True(default(int) != generatedStubData.ComplexType.IntegerProperty);
        }

        [Fact(DisplayName = "Should Generate Data For Collection Types")]
        public void Should_Generate_Data_For_Collection_Types()
        {
            var generatedStubData = _stubManager.CreateNew<ModelWithComplexTypeProperty>();
            Assert.NotEmpty(generatedStubData.CollectionTypeComplex);
            Assert.True(generatedStubData.CollectionTypeComplex[0].IntegerProperty != default(int));
        }

        [Fact(DisplayName = "Should Set Given Values While Generating Data")]
        public void Should_Set_Given_Values_While_Generating_Data()
        {
            var givenDataTime = new DateTime(2017, 1, 1);
            var givenEnum = EnTestEnum.Option3;
            var givenInteger = 31;
            var generatedStubData = _stubManager.CreateNew<InnerComplexType>(setDefaults: x => { x.DateTimeProperty = givenDataTime; x.EnumProperty = givenEnum; x.IntegerProperty = givenInteger; });
            Assert.Equal(givenDataTime, generatedStubData.DateTimeProperty);
            Assert.Equal(givenEnum, generatedStubData.EnumProperty);
            Assert.Equal(givenInteger, generatedStubData.IntegerProperty);
        }

        [Fact(DisplayName = "Should Generate Data For Complex Type Properties Check Parameterless")]
        public void Should_Generate_Data_For_Complex_Type_Properties_Check_Parameterless()
        {
            var generatedStubData = _stubManager.CreateNew<ModelWithComplexTypeProperty>();
            Assert.NotNull(generatedStubData.ComplexType);
            Assert.NotNull(generatedStubData.ModelConstructorMixed);
            Assert.Null(generatedStubData.ModelConstructorHasParameters);
        }


        [Fact(DisplayName = "Should Unsupported Types Are Null")]
        public void Should_Unsupported_Types_Are_Null()
        {
            var generatedStubData = _stubManager.CreateNew<UnsupportedTypes>();
            Assert.NotNull(generatedStubData);
            Assert.Null(generatedStubData.ByteArray);
        }


        [Fact(DisplayName = "Should Generate Generic Class")]
        public void Should_Generate_Generic_Class()
        {
            var generatedStubData = _stubManager.InvokeCreateNew("StubGenerator.Test.Models.GenericModel<StubGenerator.Test.Models.ModelWithComplexTypeProperty, StubGenerator.Test.Models>, StubGenerator.Test.Models");
            Assert.NotNull(generatedStubData);
        }

        [Fact(DisplayName = "Should Generate Generic Class With Argument Count Specified")]
        public void Should_Generate_Generic_Class_With_Argument_Count_Specified()
        {
            var generatedStubData = _stubManager.InvokeCreateNew("StubGenerator.Test.Models.GenericModel`1<StubGenerator.Test.Models.ModelWithComplexTypeProperty, StubGenerator.Test.Models>, StubGenerator.Test.Models");
            Assert.NotNull(generatedStubData);
        }


        [Fact(DisplayName = "Should Generate Generic Class With 2 Argument")]
        public void Should_Generate_Generic_Class_With_2_Argument()
        {
            var generatedStubData = _stubManager.InvokeCreateNew("StubGenerator.Test.Models.GenericModel<StubGenerator.Test.Models.ModelWithComplexTypeProperty, StubGenerator.Test.Models;StubGenerator.Test.Models.ComplexModel, StubGenerator.Test.Models>, StubGenerator.Test.Models");
            Assert.NotNull(generatedStubData);
        }

        [Fact(DisplayName = "Should Generate Generic Class With 2 Argument Count Specified")]
        public void Should_Generate_Generic_Class_With_2_Argument_Count_Specified()
        {
            var generatedStubData = _stubManager.InvokeCreateNew("StubGenerator.Test.Models.GenericModel`2<StubGenerator.Test.Models.ModelWithComplexTypeProperty, StubGenerator.Test.Models;StubGenerator.Test.Models.ComplexModel, StubGenerator.Test.Models>, StubGenerator.Test.Models");
            Assert.NotNull(generatedStubData);
        }


        [Fact(DisplayName = "Should Set Given Value Property Has Default Value Attribute")]
        public void Should_Set_Given_Value_Property_Has_Default_Value_Attribute()
        {
            var generatedStubData = _stubManager.CreateNew<DefaultValueTestModel>();
            Assert.NotNull(generatedStubData);
            Assert.Equal(DefaultValueTestModel.defaultEmail, generatedStubData.Email);
            Assert.Equal(DefaultValueTestModel.defaultEnum, generatedStubData.TestEnum);
            Assert.Equal(DefaultValueTestModel.defaultInt, generatedStubData.TestInt);
        }


        [Fact(DisplayName = "Should Set Null Value If Property Has Ignore Attribute")]
        public void Should_Set_Null_Value_If_Property_Has_Ignore_Attribute()
        {
            var generatedStubData = _stubManager.CreateNew<DefaultValueTestModel>();
            Assert.NotNull(generatedStubData);
            Assert.Null(generatedStubData.Country);
        }
    }
}
