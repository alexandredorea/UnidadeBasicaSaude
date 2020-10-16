using AMcom.Ubs.Dominio.Contratos;

namespace AMcom.Ubs.Teste.Builders.Contratos
{
    internal class UnidadeSaudeContratoBuilder
    {
        private double latitude;
        private double longitude;

        public UnidadeSaudeContratoBuilder()
        {
            latitude = -10.01;
            longitude = -37.04;
        }

        public UnidadeSaudeContratoBuilder ComLatitude(double latitude)
        {
            this.latitude = latitude;
            return this;
        }

        public UnidadeSaudeContratoBuilder ComLongitude(double longitude)
        {
            this.longitude = longitude;
            return this;
        }

        internal UnidadeSaudeContrato Construir()
        {
            return new UnidadeSaudeContrato
            {
                Latitude = latitude,
                Longitude = longitude
            };
        }
    }
}