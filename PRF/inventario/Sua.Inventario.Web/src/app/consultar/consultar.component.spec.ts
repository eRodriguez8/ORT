import { NO_ERRORS_SCHEMA } from "@angular/core";
import { ConsultarComponent } from "./consultar.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("ConsultarComponent", () => {

  let fixture: ComponentFixture<ConsultarComponent>;
  let component: ConsultarComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [ConsultarComponent]
    });

    fixture = TestBed.createComponent(ConsultarComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
