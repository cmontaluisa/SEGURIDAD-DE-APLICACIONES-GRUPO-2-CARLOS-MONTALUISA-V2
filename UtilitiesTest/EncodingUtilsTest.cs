using UPS.Utilities;
using System.Text;

namespace UPS.TestUnit
{
    /// <summary>
    /// Unit Test hola Mundo
    /// </summary>
    public class EncodingUtilsTest
    {
        [Fact]
        public void EncodeToBase64_ShouldEncodeStringCorrectly()
        {
            // Arrange
            string input = "Hola Mundo";
            string expected = "SG9sYSBNdW5kbw==";

            // Act
            string result = EncodingUtils.Current.EncodeToBase64(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EncodeToBase64_WithNullOrEmpty_ShouldReturnEmpty()
        {
            // Act
            string resultNull = EncodingUtils.Current.EncodeToBase64(null!);
            string resultEmpty = EncodingUtils.Current.EncodeToBase64(string.Empty);

            // Assert
            Assert.Equal(string.Empty, resultNull);
            Assert.Equal(string.Empty, resultEmpty);
        }

        [Fact]
        public void DecodeFromBase64_ShouldDecodeStringCorrectly()
        {
            // Arrange
            string input = "SG9sYSBNdW5kbw==";
            string expected = "Hola Mundo";

            // Act
            string result = EncodingUtils.Current.DecodeFromBase64(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DecodeFromBase64_WithNullOrEmpty_ShouldReturnEmpty()
        {
            // Act
            string resultNull = EncodingUtils.Current.DecodeFromBase64(null!);
            string resultEmpty = EncodingUtils.Current.DecodeFromBase64(string.Empty);

            // Assert
            Assert.Equal(string.Empty, resultNull);
            Assert.Equal(string.Empty, resultEmpty);
        }

        [Fact]
        public void EncodeAndDecode_ShouldBeConsistent()
        {
            // Arrange
            string original = "Texto de prueba con caracteres especiales: αινσϊ ρ";

            // Act
            string encoded = EncodingUtils.Current.EncodeToBase64(original);
            string decoded = EncodingUtils.Current.DecodeFromBase64(encoded);

            // Assert
            Assert.Equal(original, decoded);
        }

        [Fact]
        public void EncodeToBase64_WithCustomEncoding_ShouldWork()
        {
            // Arrange
            string input = "Hola";
            Encoding encoding = Encoding.Unicode;
            // "Hola" in Unicode (UTF-16LE) is 48 00 6F 00 6C 00 61 00
            // Base64 of that is SAByAGwAYQA=
            string expected = Convert.ToBase64String(encoding.GetBytes(input));

            // Act
            string result = EncodingUtils.Current.EncodeToBase64(input, encoding);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
