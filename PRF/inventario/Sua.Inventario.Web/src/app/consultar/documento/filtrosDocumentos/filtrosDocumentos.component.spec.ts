import { NO_ERRORS_SCHEMA } from "@angular/core";
import { FiltrosDocumentosComponent } from "./filtrosDocumentos.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("FiltrosDocumentosComponent", () => {

  let fixture: ComponentFixture<FiltrosDocumentosComponent>;
  let component: FiltrosDocumentosComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [FiltrosDocumentosComponent]
    });

    fixture = TestBed.createComponent(FiltrosDocumentosComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });

});
