import { Component, OnInit, ChangeDetectorRef } from "@angular/core";
import { Observable } from "rxjs";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { map, startWith } from "rxjs/operators";
import regioes from "./assets/states.json";

@Component({
  selector: "hb-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.scss"]
})
export class ProfileComponent implements OnInit {
  img: string;

  estados: string[] = regioes.estados.map(estado => estado.nome);
  cidades: string[];

  estadosFiltrados: Observable<string[]>;
  cidadesFiltradas: Observable<string[]>;
  formPerfil: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private changeDetector: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.formPerfil = this.formBuilder.group({
      estado: this.formBuilder.control("", [Validators.required]),
      cidade: this.formBuilder.control("", [Validators.required])
    });

    this.estadosFiltrados = this.get("estado").valueChanges.pipe(
      startWith(""),
      map(value => this.filter(value))
    );
  }

  selectImg() {
    document.getElementById("imgupload").click();
  }

  removeImg() {
    //this.form.get("fotoPerfil").setValue(this.baseImg);
  }

  setFile(event) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);

      reader.onload = () => {
        this.img = reader.result.toString();
        this.changeDetector.markForCheck();
      };
    }
  }

  hasImageDefined() {
    return this.img && this.img !== "";
  }

  private filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.estados.filter(option =>
      option.toLowerCase().includes(filterValue)
    );
  }

  setCidades() {
    if (this.get("estado").value) {
      this.get("cidade").setValue("");
      this.cidades = this.filtrarCidadesPorEstado(
        <string>this.get("estado").value
      );
      this.cidadesFiltradas = this.get("cidade").valueChanges.pipe(
        startWith(""),
        map(value => this.filtrarCidades(value))
      );
    }
  }

  private filtrarCidadesPorEstado(estado: string): string[] {
    const estadoCidades = regioes.estados.filter(_estado =>
      _estado.nome.toLocaleLowerCase().includes(estado.toLocaleLowerCase())
    );

    if (estadoCidades && estadoCidades.length > 0) {
      this.cidades = estadoCidades[0].cidades;
      return estadoCidades[0].cidades;
    }
    return [];
  }

  private filtrarCidades(cidade: string): string[] {
    if (this.cidades) {
      const filterValue = cidade.toLowerCase();
      return this.cidades.filter(option =>
        option.toLowerCase().includes(filterValue)
      );
    }
  }

  private get(controlName: string) {
    return this.formPerfil.get(controlName);
  }
}
