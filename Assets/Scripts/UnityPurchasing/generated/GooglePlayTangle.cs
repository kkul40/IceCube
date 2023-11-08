// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("aWXw53oCsyk2wvVXbIhvtIetuKuscAf23ZGNcVGD4k6Elu1rv9cawyMyqAfxm9q7e7/FC0XtJVUBZnpOHp2TnKwenZaeHp2dnB2EndUo1z8mwfNRHxP9gpPFr/YcJggpLEuzeABI23G+tiIcgaL6EZndRzADE0PQp5MXVi9TfVIrI4urj0wwE5PesoQ4wQxzzuVF7N1QRa1RU43IfrrlyvLudaqUiOUZAwihIj4py/Gdc+OGCel5bx2eHDYkcWrhg4ckx8vGkQOsHp2+rJGalbYa1BprkZ2dnZmcn3/eSdjP2z0OfmeL0xD/3gUfef5tXlRDQgK/H2EujTA/DeBCzIdYIP0EIwNpCKNh5hjE3nCWwZ9ScR1WLq2X99kHJEYn2Z6fnZyd");
        private static int[] order = new int[] { 3,11,13,11,10,13,6,12,13,13,11,12,13,13,14 };
        private static int key = 156;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
