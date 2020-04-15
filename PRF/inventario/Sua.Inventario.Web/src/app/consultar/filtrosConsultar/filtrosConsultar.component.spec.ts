import { NO_ERRORS_SCHEMA } from "@angular/core";
import { FiltrosConsultarComponent } from "./filtrosConsultar.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("FiltrosConsultarComponent", () => {

  let fixture: ComponentFixture<FiltrosConsultarComponent>;
  let component: FiltrosConsultarComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [FiltrosConsultarComponent]
    });

    fixture = TestBed.createComponent(FiltrosConsultarComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
