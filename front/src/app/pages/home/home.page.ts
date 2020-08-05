import { Component, OnInit } from '@angular/core';
import { ToastrManager  } from 'ng6-toastr-notifications';
import { Router } from '@angular/router';
import { EnderecoService } from '../../services/endereco.service';
import { EnderecoModel } from '../../model/endereco.model';

@Component({
  selector: 'home-page',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.css']
})
export class HomePage implements OnInit {

  public model: EnderecoModel = new EnderecoModel();

  constructor(
     private _service: EnderecoService,
     public toastr: ToastrManager,
     private _router: Router ) { }

  ngOnInit(){
  }

  private getEndereco(){

    if(!this.model.CEP){
      this.toastr.warningToastr("O CEP é obrigatório");
      return;
    }

    if(this.model.CEP.length < 7){
      this.toastr.errorToastr("CEP inválido");
      return;
    }

    this._service.getEndereco(this.model.CEP)
       .subscribe(x => {
          if(x.CEP){
            x.Complemento = "";
            this.model = x;
          }else
           this.toastr.warningToastr("CEP não encontrado");
       },
       error => {
         console.log(error);
         this.toastr.errorToastr("Ocorreu um erro em sua solicitação");
       })
   }

   enderecoIsValid() : boolean{
     if(this.model.CEP && this.model.Bairro && this.model.Cidade
        && this.model.Logradouro && this.model.Numero && this.model.Uf)
         return true;
      else
         return false;
   }
}
