using System.Text;
using System.Text.RegularExpressions;

namespace UPS.Utilities
{
    /// <summary>
    /// Clase con métodos para codificar y decodificar cadenas en Base64
    /// </summary>
    public sealed class EncodingUtils
    {
        private static readonly Lazy<EncodingUtils> _lazy = new(() => new EncodingUtils());

        /// <summary>
        /// Obtiene la instancia singleton de EncodingUtils
        /// </summary>
        public static EncodingUtils Current => _lazy.Value;

        private EncodingUtils()
        {
        }

        /// <summary>
        /// Codifica una cadena en Base64 usando UTF-8
        /// </summary>
        /// <param name="text">Texto a codificar.</param>
        /// <returns>Texto codificado en Base64.</returns>
        public string EncodeToBase64(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            byte[]? b = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(b);
        }

        /// <summary>
        /// Codifica una cadena en Base64 usando la codificación indicada, si no se indica ninguna usa la codificación por defecto del sistema
        /// </summary>
        /// <param name="text">Texto a codificar.</param>
        /// <param name="encoding">Codificación a utilizar.</param>
        /// <returns>Texto codificado en Base64.</returns>
        public string EncodeToBase64(string text, Encoding? encoding)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            encoding ??= Encoding.Default;

            byte[] bytes = encoding.GetBytes(text);

            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Decodifica una cadena en Base64 usando UTF-8
        /// </summary>
        /// <param name="base64Text">Texto en Base64 a decodificar.</param>
        /// <returns>Texto decodificado.</returns>
        public string DecodeFromBase64(string base64Text)
        {
            if (string.IsNullOrEmpty(base64Text))
                return string.Empty;

            byte[] base64Bytes = Convert.FromBase64String(base64Text);
            return Encoding.UTF8.GetString(base64Bytes);
        }

        /// <summary>
        /// Decodifica una cadena en Base64 usando la codificación indicada, si no se indica ninguna usa la codificación por defecto del sistema
        /// </summary>
        /// <param name="base64Text"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public string DecodeFromBase64(string base64Text, Encoding? encoding)
        {
            if (string.IsNullOrEmpty(base64Text))
                return string.Empty;

            encoding ??= Encoding.Default;

            var bytes = Convert.FromBase64String(base64Text);
            return encoding.GetString(bytes);
        }
    }
}




