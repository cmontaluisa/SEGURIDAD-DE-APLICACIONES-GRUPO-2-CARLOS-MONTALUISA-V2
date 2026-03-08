using UPS.Utilities;
using System.Text;

namespace UPS.TestUnit
{
    /// <summary>
    /// Unit Test Pruebas
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
            string original = "Texto de prueba con caracteres especiales: ����� �";

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

        [Fact]
        public void DecodeFromBase64_WithCustomEncoding_ShouldWork()
        {
            // Arrange
            string expected = "Hola";
            Encoding encoding = Encoding.Unicode;
            string input = Convert.ToBase64String(encoding.GetBytes(expected));

            // Act
            string result = EncodingUtils.Current.DecodeFromBase64(input, encoding);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertBytesToBase64_ShouldConvertCorrectly()
        {
            // Arrange
            byte[] input = [72, 111, 108, 97]; // "Hola"
            string expected = "SG9sYQ==";

            // Act
            string result = EncodingUtils.Current.ConvertBytesToBase64(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertBytesToBase64_WithNullOrEmpty_ShouldReturnEmpty()
        {
            // Act
            string resultNull = EncodingUtils.Current.ConvertBytesToBase64(null);
            string resultEmpty = EncodingUtils.Current.ConvertBytesToBase64([]);

            // Assert
            Assert.Equal(string.Empty, resultNull);
            Assert.Equal(string.Empty, resultEmpty);
        }

        [Fact]
        public void ConvertFromBase64ToBytes_ShouldConvertCorrectly()
        {
            // Arrange
            string input = "SG9sYQ==";
            byte[] expected = [72, 111, 108, 97]; // "Hola"

            // Act
            byte[]? result = EncodingUtils.Current.ConvertFromBase64ToBytes(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertFromBase64ToBytes_WithNullOrEmpty_ShouldReturnEmptyArray()
        {
            // Act
            byte[]? resultNull = EncodingUtils.Current.ConvertFromBase64ToBytes(null);
            byte[]? resultEmpty = EncodingUtils.Current.ConvertFromBase64ToBytes(string.Empty);

            // Assert
            Assert.Empty(resultNull!);
            Assert.Empty(resultEmpty!);
        }

        [Fact]
        public void IsBase64String_ShouldValidateCorrectly()
        {
            // Valid Base64
            Assert.True(EncodingUtils.Current.IsBase64String("SG9sYQ=="));
            Assert.True(EncodingUtils.Current.IsBase64String("SG9sYSBNdW5kbw=="));
            
            // Invalid length
            Assert.False(EncodingUtils.Current.IsBase64String("S"));
            
            // Invalid characters
            Assert.False(EncodingUtils.Current.IsBase64String("SG9sYQ==!"));
            
            // Null or empty
            Assert.False(EncodingUtils.Current.IsBase64String(null!));
            Assert.False(EncodingUtils.Current.IsBase64String(string.Empty));
            Assert.False(EncodingUtils.Current.IsBase64String("   "));
        }
    }
}
