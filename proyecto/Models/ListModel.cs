using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace proyecto.Models
{
    public class ListModel
    {
        public int? id {get;set;}
        [Required(ErrorMessage = "Name is required")]
        public string nombres{ get;set;}
        [Required]
        public string apaterno{ get;set;}
        [Required]
        public string amaterno{ get;set;}
        [Required]
        public string dni {get;set;}
        [Required]
        public string fechanac {get;set;}
        [Required]
        public string sexo {get;set;}
        [Required]
        public string distrito {get;set;}
        [Required]        
        [RegularExpression(@"\d{9}", ErrorMessage = "Please enter 9 digit Mobile No.")]
        public string celular {get;set;}
        [Required]
        public string estado {get;set;}
        [Required]
        public string fechacreacion {get;set;}

        public List<ListModel> ListaPersonas(){
            List<ListModel> lista = new List<ListModel>(){
                new ListModel(){id=1, nombres="ANA", apaterno="SANCHEZ", amaterno ="MATA", dni="0892716", fechanac="01/05/1962", sexo="F", distrito="SAN BORJA", celular=979753598, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=2, nombres="ANDREA", apaterno="PEREZ", amaterno ="SANTOS", dni="9658472", fechanac="03/10/1967", sexo="F", distrito="LIMA", celular=959594476, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=3, nombres="CARLOS", apaterno="NORIEGA", amaterno ="VEGA", dni="6584412", fechanac="22/09/1972", sexo="M", distrito="ATE", celular=962849096, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=4, nombres="ALEX", apaterno="SANDOVAL", amaterno ="GUERRERO", dni="9565481", fechanac="17/10/1975", sexo="M", distrito="SAN MIGUEL", celular=939051514, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=5, nombres="DANIELA", apaterno="JIMENEZ", amaterno ="LLANOS", dni="6954841", fechanac="23/02/1978", sexo="F", distrito="CHORRILLOS", celular=984129703, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=6, nombres="FRANK", apaterno="FLORES", amaterno ="COSTA", dni="8665415", fechanac="12/05/1980", sexo="M", distrito="INDEPENDENCIA", celular=953773423, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=7, nombres="JAIME", apaterno="GRANDA", amaterno ="ACOSTA", dni="0874152", fechanac="21/10/1982", sexo="M", distrito="SAN MIGUEL", celular=977298557, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=8, nombres="PEDRO", apaterno="RODRIGUEZ", amaterno ="SOLARI", dni="0664857", fechanac="27/11/1984", sexo="M", distrito="LA VICTORIA", celular=945066035, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=9, nombres="PENELOPE", apaterno="HIDALGO", amaterno ="SILVA", dni="8574152", fechanac="19/08/1987", sexo="F", distrito="LOS OLIVOS", celular=969460423, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=10, nombres="SARA", apaterno="RUIZ", amaterno ="DELGADO", dni="9568547", fechanac="24/11/1989", sexo="F", distrito="LA VICTORIA", celular=963133498, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=11, nombres="SANDRA", apaterno="NAVARRO", amaterno ="ROSALES", dni="7254856", fechanac="10/03/1992", sexo="F", distrito="LA VICTORIA", celular=934456833, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=12, nombres="SAMUEL", apaterno="VILLANUEVA", amaterno ="AGUILAR", dni="7145523", fechanac="26/07/1994", sexo="M", distrito="BREÑA", celular=966789121, estado="INACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=13, nombres="JUAN", apaterno="VILLEGAS", amaterno ="GARCIA", dni="6078457", fechanac="08/01/1997", sexo="M", distrito="BREÑA", celular=924555505, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=14, nombres="MARTIN", apaterno="BRAVO", amaterno ="PACHECO", dni="3526548", fechanac="10/07/1999", sexo="M", distrito="ATE", celular=952916798, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=15, nombres="MADELEINE", apaterno="MORON", amaterno ="ESPINOZA", dni="0458746", fechanac="13/10/1975", sexo="F", distrito="CHORRILLOS", celular=952393996, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() },
                new ListModel(){id=16, nombres="MANUEL", apaterno="TORRES", amaterno ="NEYRA", dni="7652315", fechanac="02/12/2003", sexo="M", distrito="SAN MIGUEL", celular=964671342, estado="ACTIVO", fechacreacion=DateTime.Now.ToString() }
             
            };
            return lista;
        }

        public ListModel DetallePersona(List<ListModel> lista, int cod){
            if(cod == 0){
                lista = new List<ListModel>(){new ListModel(){nombres="ERROR"}};
                return lista[cod];
            }
            else{
                return lista[cod-1];
            }
        }
        public List<SelectListItem> lstDistritos = new List<SelectListItem>(){
            new SelectListItem(){Text = "ATE",Value = "ATE"},
            new SelectListItem(){Text = "BREÑA",Value = "BREÑA"},
            new SelectListItem(){Text = "CHORRILLOS",Value = "CHORRILLOS"},
            new SelectListItem(){Text = "INDEPENDENCIA",Value = "INDEPENDENCIA"},
            new SelectListItem(){Text = "LA VICTORIA",Value = "LA VICTORIA"},
            new SelectListItem(){Text = "LIMA",Value = "LIMA"},
            new SelectListItem(){Text = "LOS OLIVOS",Value = "LOS OLIVOS"},
            new SelectListItem(){Text = "SAN BORJA",Value = "SAN BORJA"},
            new SelectListItem(){Text = "SAN MIGUEL",Value = "SAN MIGUEL"}
        };
        
        public List<SelectListItem> lstEstados = new List<SelectListItem>(){
            new SelectListItem(){Text = "ACTIVO",Value = "ACTIVO"},
            new SelectListItem(){Text = "INACTIVO",Value = " INACTIVO"}
        };        
        public List<SelectListItem> lstSexos = new List<SelectListItem>(){
            new SelectListItem(){Text = "HOMBRE",Value = "HOMBRE"},
            new SelectListItem(){Text = "MUJER",Value = " MUJER"},
            new SelectListItem(){Text = "OTRO",Value = "OTRO"}
        };

    }
            
}