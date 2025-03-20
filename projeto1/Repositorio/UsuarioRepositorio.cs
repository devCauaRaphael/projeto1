using projeto1.Models;

namespace projeto1.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly string _connectionString;

        public UsuarioRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "INSERT INTO Usuario (Nome, Email, Senha) VALUES (@Nome,@Email,@Senha)";
                cmd.Parameters.AddWithValue("@Nome", usuario.nome);
                cmd.Parameters.AddWithValue("@Email", usuario.email);
                cmd.Parameters.AddWithValue("@Senha", usuario.senha);
                cmd.ExecuteNonQuery();

            }
        }
        public Usuario ObterUsuario(string email)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Usuario WHERE Email = @Email";
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteNonQuery();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            Id = reader.GetInt32("Id"),
                            nome = reader.GetString("Nome"),
                            email = reader.GetString("Email"),
                            senha = reader.GetString("Senha"),

                        };

                    }

                }
                return null;
            }
        }
    }
}

