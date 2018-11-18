using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.Entity
{
    public class LoginENT
    {
        public Int16 codigo;
        public string usuario;
        public string senha;
        public Int16 cod_grupo;
        public string grupo;
        public Int16 cod_empresa;
        public string empresa;        
        public DateTime data_cadastro;
        public DateTime data_atualizacao;
        public string maquina;
        public string versao;
        public DateTime data_ult_login;
        public bool aprovado;
        public bool ativo;
    }
}