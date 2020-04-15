import { NO_ERRORS_SCHEMA } from "@angular/core";
import { PosicionComponent } from "./posiciones.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("PosicionComponent", () => {

  let fixture: ComponentFixture<PosicionComponent>;
  let component: PosicionComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [PosicionComponent]
    });

    fixture = TestBed.createComponent(PosicionComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });

});
