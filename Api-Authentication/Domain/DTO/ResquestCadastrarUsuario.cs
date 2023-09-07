namespace Api_Authentication.Domain.DTO
{
    public struct ResquestCadastrarUsuario
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Matricula { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
