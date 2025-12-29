import { AutoMap } from "@automapper/classes";

export class AuthorResponse {
  constructor() {
    this.authorId = '';
    this.name = '';
    this.age = 0;
    this.genre = '';
    this.firstName = '';
    this.lastName = '';
    this.dateOfBirth = new Date();
  }

  @AutoMap()
  public authorId: string;
  @AutoMap()
  public name: string;
  @AutoMap()
  public age: number;
  @AutoMap()
  public genre: string;
  @AutoMap()
  public firstName: string;
  @AutoMap()
  public lastName: string;
  @AutoMap()
  public dateOfBirth: Date;
}
