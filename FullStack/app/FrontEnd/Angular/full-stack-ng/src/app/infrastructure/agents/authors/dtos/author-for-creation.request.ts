import { AutoMap } from "@automapper/classes";

export class AuthorForCreationRequest {
  constructor() {
    this.firstName = '';
    this.lastName = '';
    this.genre = '';
    this.dateOfBirth = new Date();
  }

  @AutoMap()
  public firstName: string;
  @AutoMap()
  public lastName: string;
  @AutoMap()
  public genre: string;
  @AutoMap()
  public dateOfBirth: Date;
}
