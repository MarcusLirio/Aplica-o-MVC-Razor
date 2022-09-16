using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marcus_mvc.Models
{
    public class Veiculos
    {
        private readonly static string _conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgenciaAuto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public short Ano { get; set; }
        public short Fabricacao { get; set; }
        public string Cor { get; set; }
        public byte Combustivel { get; set; }
        public bool Automatico { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }

        public Veiculos() { }

        public Veiculos(int id, string nome, string modelo, short ano, short fabricacao, string cor, byte combustivel, bool automatico, decimal valor, bool ativo)
        {
            Id = id;
            Nome = nome;
            Modelo = modelo;
            Ano = ano;
            Fabricacao = fabricacao;
            Cor = cor;
            Combustivel = combustivel;
            Automatico = automatico;
            Valor = valor;
            Ativo = ativo;
        }

        public static List<Veiculos> GetVeiculos()
        {
            var listaVeiculos = new List<Veiculos>();
            var sql = "SELECT * FROM tb_Veiculos";

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    listaVeiculos.Add(new Veiculos(
                                            Convert.ToInt32(dr["Id"]),
                                            dr["Nome"].ToString(),
                                            dr["Modelo"].ToString(),
                                            Convert.ToInt16(dr["Ano"]),
                                            Convert.ToInt16(dr["Fabricacao"]),
                                            dr["Cor"].ToString(),
                                            Convert.ToByte(dr["Combustivel"]),
                                            Convert.ToBoolean(dr["Automatico"]),
                                            Convert.ToDecimal(dr["Valor"]),
                                            Convert.ToBoolean(dr["Ativo"])
                                        ));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listaVeiculos;
        }

        public void Salvar()
        {
            var sql = "";
            if (Id == 0)
                sql = "INSERT INTO tb_Veiculos (nome, modelo, ano, fabricacao, cor, combustivel, automatico, valor, ativo) VALUES (@nome, @modelo, @ano, @fabricacao, @cor, @combustivel, @automatico, @valor, @ativo)";
            else
                sql = "UPDATE tb_Veiculos SET nome=@nome, modelo=@modelo, ano=@ano, fabricacao=@fabricacao, cor=@cor, combustivel=@combustivel, automatico=@automatico, valor=@valor, ativo=@ativo WHERE id=" + Id;
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nome", Nome);
                        cmd.Parameters.AddWithValue("@modelo", Modelo);
                        cmd.Parameters.AddWithValue("@ano", Fabricacao);
                        cmd.Parameters.AddWithValue("@fabricacao", Fabricacao);
                        cmd.Parameters.AddWithValue("@cor", Cor);
                        cmd.Parameters.AddWithValue("@combustivel", Combustivel);
                        cmd.Parameters.AddWithValue("@automatico", Automatico);
                        cmd.Parameters.AddWithValue("@valor", Valor);
                        cmd.Parameters.AddWithValue("@ativo", Ativo);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
        }

        public void Excluir()
        {
            var sql = "DELETE FROM tb_Veiculos WHERE id=" + Id;

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: "+ ex.Message);
            }
        }



        public void GetVeiculo(int id)
        {
            var sql = "SELECT nome, modelo, ano, fabricacao, cor, combustivel, automatico, valor, ativo FROM tb_Veiculos WHERE id=" + id;
            try
            {
                using(var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using(var cmd= new SqlCommand(sql, cn))
                    {
                        using(var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    Id = id;
                                    Nome = dr["Nome"].ToString();
                                    Modelo = dr["Modelo"].ToString();
                                    Ano = Convert.ToInt16(dr["Ano"]);
                                    Fabricacao = Convert.ToInt16(dr["Fabricacao"]);
                                    Cor = dr["Cor"].ToString();
                                    Combustivel = Convert.ToByte(dr["Combustivel"]);
                                    Automatico = Convert.ToBoolean(dr["Automatico"]);
                                    Valor = Convert.ToDecimal(dr["Valor"]);
                                    Ativo = Convert.ToBoolean(dr["Ativo"]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Nome = "Falha: " + ex.Message;
                Console.WriteLine("Falha: "+ ex.Message);
            }
        }
    }
}