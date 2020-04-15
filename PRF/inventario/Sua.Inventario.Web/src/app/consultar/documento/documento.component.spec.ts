import { NO_ERRORS_SCHEMA } from "@angular/core";
import { DocumentoComponent } from "./documento.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("DocumentoComponent", () => {

  let fixture: ComponentFixture<DocumentoComponent>;
  let component: DocumentoComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [DocumentoComponent]
    });

    fixture = TestBed.createComponent(DocumentoComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
