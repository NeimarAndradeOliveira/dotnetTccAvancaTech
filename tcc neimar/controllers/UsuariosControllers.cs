using tcc_neimar.Models;
using MySql.Data.MySqlClient;

namespace tcc_neimar.Controllers
{
    public class UsuariosController()
    {
        private readonly string  conexao =

        "server=localhost;database=estacao_saude;uid=root;pwd=;";
    
        public List<Usuarios>Listar()
        {
                List<Usuarios> lista = new ();
                
                using MySqlConnection conn = new (conexao);

                conn.Open ();

                string sql = "SELECT * FROM usuarios";
                MySqlCommand cmd = new(sql, conn);


                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    lista.Add(new Usuarios
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nome = reader["nome"].ToString()!,
                        Idade = Convert.ToInt32(reader["idade"]),
                        Sexo = reader["sexo"].ToString()!,
                        Endereco = reader["endereço"].ToString()!,
                        Telefone = Convert.ToInt32(reader["telefone"]),
                        Email = reader["email"].ToString()!,
                        Patologia = reader["patologia"].ToString()!,
                        TipoPatologia = reader["tipoPatologia"].ToString()!,
                        TipoExame = reader["TipoExame"].ToString()!,
                        Resultado = reader["resultado"].ToString()!
                    });
                }
                return lista;

            }

       public void Inserir(Usuarios usuario)
        {
            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();


                string sql =
                    @"INSERT INTO usuarios
                    (nome, idade, sexo, endereço,telefone,email,patologia,tipoPatologia,TipoExame,resultado)
                    VALUES
                    (@nome,@idade,@sexo,@endereço,@telefone,@email,@patologia,@tipoPatologia,@TipoExame,@resultado)";


                MySqlCommand cmd = new(sql, conn);


                cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@idade", usuario.Idade);
                cmd.Parameters.AddWithValue("@sexo", usuario.Sexo);
                cmd.Parameters.AddWithValue("@endereço", usuario.Endereco);
                cmd.Parameters.AddWithValue("@telefone", usuario.Telefone);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@patologia", usuario.Patologia);
                cmd.Parameters.AddWithValue("@tipoPatologia", usuario.TipoPatologia);
                cmd.Parameters.AddWithValue("@tipoExame", usuario.TipoExame);
                cmd.Parameters.AddWithValue("@resultado", usuario.Resultado);
                


                cmd.ExecuteNonQuery();
            }
        }
        public Usuarios BuscarPorId(int id)
        {
            Usuarios usuario = new();


            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();


                string sql =
                    "SELECT * FROM usuarios WHERE id=@id";


                MySqlCommand cmd = new(sql, conn);


                cmd.Parameters.AddWithValue("@id", id);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario.Id = Convert.ToInt32(reader["id"]);
                        usuario.Nome = reader["nome"].ToString()!;
                        usuario.Idade = Convert.ToInt32(reader["idade"])!;
                        usuario.Sexo = reader["sexo"].ToString()!;
                        usuario.Endereco = reader["nome"].ToString()!;
                        usuario.Telefone = Convert.ToInt32(reader["telefone"])!;
                        usuario.Patologia = reader["patologia"].ToString()!;
                        usuario.TipoPatologia = reader["tipoPatologia"].ToString()!;
                        usuario.TipoExame = reader["TipoExame"].ToString()!;
                        usuario.Resultado = reader["resultado"].ToString()!;

                        
                    }
                }
            }


            return usuario;
        }
        public void Atualizar(Usuarios usuarios)
        {
            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();


                string sql =
                    @"UPDATE usuarios
                    SET nome=@nome,
                        sexo=@sexo,
                        idade=@idade,
                        sexo=@sexo,
                        endereço=@endereço,
                        telefone=@telefone,
                        patologia=@telefone,
                        tipoPatologia=@tipoPatologia,
                        TipoExame=@TipoExame,
                        resultado=@resultado
                    WHERE id=@id";


                MySqlCommand cmd = new(sql, conn);


                cmd.Parameters.AddWithValue("@id", usuarios.Id);
                cmd.Parameters.AddWithValue("@nome", usuarios.Nome);
                cmd.Parameters.AddWithValue("@sexo", usuarios.Sexo);
                cmd.Parameters.AddWithValue("@idade", usuarios.Idade);
                cmd.Parameters.AddWithValue("@endereço", usuarios.Endereco);
                cmd.Parameters.AddWithValue("@telefone", usuarios.Telefone);
                cmd.Parameters.AddWithValue("@patologia", usuarios.Patologia);
                cmd.Parameters.AddWithValue("@tipoPatologia", usuarios.TipoPatologia);
                cmd.Parameters.AddWithValue("@TipoExame", usuarios.TipoExame);
                cmd.Parameters.AddWithValue("@resultado", usuarios.Resultado);


                cmd.ExecuteNonQuery();
            }
        }


        public void Excluir(int id)
        {
            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();


                string sql =
                    "DELETE FROM usuarios WHERE id=@id";


                MySqlCommand cmd = new(sql, conn);


                cmd.Parameters.AddWithValue("@id", id);


                cmd.ExecuteNonQuery();
            }
        }
    }
}









        



    


