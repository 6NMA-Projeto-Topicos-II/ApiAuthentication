namespace Api_Authentication.Domain.DTO
{
    public struct InputRegisterUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Registration { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
