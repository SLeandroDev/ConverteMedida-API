using static ConversorDeMedidas.API.Services.ConversorServiceComprimento;

namespace ConversorDeMedidas.API.Services
{
    public class ConversorServiceComprimento
    {
        public enum UnidadeComprimento
        {
            Metros,
            centimetros,
            Polegadas
        }
        public double Converter(double valor, UnidadeComprimento unidadeOrigem, UnidadeComprimento unidadeDestino)
        {
            // Lógica de conversão ()

            var conversao = new Dictionary<(UnidadeComprimento, UnidadeComprimento), double>
            {
                {(UnidadeComprimento.Metros, UnidadeComprimento.centimetros), 100},
                {(UnidadeComprimento.centimetros, UnidadeComprimento.Metros), 0.01},
                {(UnidadeComprimento.Polegadas, UnidadeComprimento.centimetros), 2.54},
                {(UnidadeComprimento.centimetros, UnidadeComprimento.Polegadas), 1 / 2.54},
                {(UnidadeComprimento.Polegadas, UnidadeComprimento.Metros), 0.0254},
                {(UnidadeComprimento.Metros, UnidadeComprimento.Polegadas), 39.37}
            };

            if (conversao.TryGetValue((unidadeOrigem, unidadeDestino), out double taxa))
            {
                return valor * taxa;
            }
            else
            {
                throw new ArgumentException("Conversão não suportada para as unidades especificadas.");
            }
        }
    }

    public class ConversorServicePeso
    {
        public enum UnidadePeso
        {
            Kg,
            Gramas,
            Toneladas
        }
        public double Converter(double valor, UnidadePeso unidadeOrigem, UnidadePeso unidadeDestino)
        {
            // Lógica de conversão ()

            var conversao = new Dictionary<(UnidadePeso, UnidadePeso), double>
            {
                {(UnidadePeso.Kg, UnidadePeso.Gramas), 1000},
                {(UnidadePeso.Gramas, UnidadePeso.Kg), 0.001},
                {(UnidadePeso.Kg, UnidadePeso.Toneladas), 0.001},
                {(UnidadePeso.Toneladas, UnidadePeso.Kg), 1000},
                {(UnidadePeso.Gramas, UnidadePeso.Toneladas), 0.000001},
                {(UnidadePeso.Toneladas, UnidadePeso.Gramas), 1000000}
            };

            if (conversao.TryGetValue((unidadeOrigem, unidadeDestino), out double taxa))
            {
                return valor * taxa;
            }
            else
            {
                throw new ArgumentException("Conversão não suportada para as unidades especificadas.");
            }
        }
    }

    public class ConversorServiceLiquido
    {
        public enum UnidadeLiquido
        {
            Litros,
            Mililitros,
            MetrosCubicos
        }

        public double Converter(double valor, UnidadeLiquido unidadeOrigem, UnidadeLiquido unidadeDestino)
        {
            // Lógica de conversão
            var conversao = new Dictionary<(UnidadeLiquido, UnidadeLiquido), double>
            {
                {(UnidadeLiquido.Litros, UnidadeLiquido.Mililitros), 1000},
                {(UnidadeLiquido.Mililitros, UnidadeLiquido.Litros), 0.001},
                {(UnidadeLiquido.Litros, UnidadeLiquido.MetrosCubicos), 0.001},
                {(UnidadeLiquido.MetrosCubicos, UnidadeLiquido.Litros), 1000},
                {(UnidadeLiquido.Mililitros, UnidadeLiquido.MetrosCubicos), 0.000001},
                {(UnidadeLiquido.MetrosCubicos, UnidadeLiquido.Mililitros), 1000000}
            };

            if (conversao.TryGetValue((unidadeOrigem, unidadeDestino), out double taxa))
            {
                return valor * taxa;
            }
            else
            {
                throw new ArgumentException("Conversão não suportada para as unidades especificadas.");
            }
        }
    }
}
