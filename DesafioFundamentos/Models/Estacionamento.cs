using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            
            if(isPlacaValida(placa))
            {
                this.veiculos.Add(placa);

                System.Console.WriteLine("Veículo adicionado com sucesso!");
            }
            else
            {
                System.Console.WriteLine("Placa inválida! Tente novamente.");
                AdicionarVeiculo();
            }
        }

        public void RemoverVeiculo()
        {
            //verifica se há veículos estacionados
            if (veiculos.Any())
            {
                //Apenas para auxiliar o usuário
                ListarVeiculos();

                Console.WriteLine("\nDigite a placa do veículo para remover:");
                string placa = Console.ReadLine();

                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo"
                        +" permaneceu estacionado:");
                    int horas = Convert.ToInt32(Console.ReadLine());

                    decimal valorTotal = this.precoInicial
                        + this.precoPorHora * horas; 

                    this.veiculos.Remove(placa);

                    Console.WriteLine($"O veículo de placa ({placa.ToUpper()}) foi removido e"
                        + $" o preço total foi de: {valorTotal.ToString("C")}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui."
                        +" Confira se digitou a placa corretamente");
                }
            }
            else{
                Console.WriteLine("Desculpe não há veículos estacionados aqui.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:\n");
                
                foreach (string item in this.veiculos)
                {
                    System.Console.WriteLine(item.ToUpper());
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool isPlacaValida(string placa){
            string separador = @"^.{3}-.{4}$";
            if(Regex.IsMatch(placa, separador))
                return true;
            else
                return false;
        }
    }
}
