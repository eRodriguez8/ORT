import { NO_ERRORS_SCHEMA } from "@angular/core";
import { AsignarComponent } from "./asignar.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("AsignarComponent", () => {

  let fixture: ComponentFixture<AsignarComponent>;
  let component: AsignarComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [AsignarComponent]
    });

    fixture = TestBed.createComponent(AsignarComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
