﻿using Biblioteca.classesBasicas;
using Biblioteca.conexao;
using Biblioteca.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.dados
{
    //esta classe herda da classe de conexão
    //e implementa suas respectivas funcionalidades

    #region segunda forma de passar parametros

    //Use AddWithValue to assign Demographics.
    //SQL Server will implicitly convert strings into XML.
    //cmd.Parameters.AddWithValue("@demographics", demoXml);

    #endregion
    public class AlunoBD : ConexaoSqlServer, InterfaceAluno
    {
        #region Método Insert
        public void Insert(Aluno aluno)
        {
            try
            {
                //abrir a conexão
                this.AbrirConexao();
                string sql = "insert into aluno (matricula,nome) ";
                sql += "values(@matricula,@nome)";
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@matricula", SqlDbType.Int);
                cmd.Parameters["@matricula"].Value = aluno.Matricula;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = aluno.Nome;

                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e inserir " + ex.Message);
            }
        }
        #endregion
        #region Método Update
        public void Update(Aluno aluno)
        {
            try
            {
                //abrir a conexão
                this.AbrirConexao();
                string sql = "update aluno set ";
                sql += " matricula = @matricula ,";
                sql += " nome = @nome ";
                sql += " where matricula = @matricula2";
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@matricula", SqlDbType.Int);
                cmd.Parameters["@matricula"].Value = aluno.Matricula;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = aluno.Nome;

                cmd.Parameters.Add("@matricula2", SqlDbType.Int);
                cmd.Parameters["@matricula2"].Value = aluno.Matricula;

                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e atualizar " + ex.Message);
            }
        }
        #endregion
        #region Método Delete
        public void Delete(Aluno aluno)
        {
            try
            {
                //abrir a conexão
                this.AbrirConexao();
                string sql = "delete from aluno where matricula = @matricula";
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@matricula", SqlDbType.Int);
                cmd.Parameters["@matricula"].Value = aluno.Matricula;
                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e remover " + ex.Message);
            }
        }
        #endregion 
        #region Método Verifica Duplicidade
        public bool VerificaDuplicidade(Aluno aluno)
        {
            bool retorno = false;
            try
            {
                this.AbrirConexao();
                //instrucao a ser executada
                string sql = "SELECT matricula,nome FROM aluno where matricula = @matricula";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.Add("@matricula", SqlDbType.Int);
                cmd.Parameters["@matricula"].Value = aluno.Matricula;
                //executando a instrucao e colocando o resultado em um leitor
                SqlDataReader DbReader = cmd.ExecuteReader();
                //lendo o resultado da consulta
                while (DbReader.Read())
                {
                    retorno = true;
                    break;
                }
                //fechando o leitor de resultados
                DbReader.Close();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e selecionar " + ex.Message);
            }
            return retorno;
        }
        #endregion 
        #region Método Select
        public List<Aluno> Select(Aluno filtro)
        {
            List<Aluno> retorno = new List<Aluno>();
            try
            {
                this.AbrirConexao();
                //instrucao a ser executada
                string sql = "SELECT matricula,nome FROM aluno where matricula = matricula ";
                //se foi passada uma matricula válida, esta matricula entrará como critério de filtro
                if (filtro.Matricula > 0)
                {
                    sql += " and matricula = @matricula";
                }
                //se foi passada um nome válido, este nome entrará como critério de filtro
                if (filtro.Nome != null && filtro.Nome.Trim().Equals("") == false)
                {
                    sql += " and nome like @nome";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                //se foi passada uma matricula válida, esta matricula entrará como critério de filtro
                if (filtro.Matricula > 0)
                {
                    cmd.Parameters.Add("@matricula", SqlDbType.Int);
                    cmd.Parameters["@matricula"].Value = filtro.Matricula;
                }
                //se foi passada um nome válido, este nome entrará como critério de filtro
                if (filtro.Nome != null && filtro.Nome.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                    cmd.Parameters["@nome"].Value = "%" + filtro.Nome + "%";

                }
                //executando a instrucao e colocando o resultado em um leitor
                SqlDataReader DbReader = cmd.ExecuteReader();
                //lendo o resultado da consulta
                while (DbReader.Read())
                {
                    Aluno aluno = new Aluno();
                    //acessando os valores das colunas do resultado
                    aluno.Matricula = DbReader.GetInt32(DbReader.GetOrdinal("matricula"));
                    aluno.Nome = DbReader.GetString(DbReader.GetOrdinal("nome"));
                    retorno.Add(aluno);
                }
                //fechando o leitor de resultados
                DbReader.Close();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e selecionar " + ex.Message);
            }
            return retorno;
        }
        #endregion 
    }
}
