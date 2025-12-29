import { createMap, createMapper, Mapper } from '@automapper/core';
import { classes } from '@automapper/classes';
import { Author } from '../../domain/entities/Auhtor.entity';
import { AuthorModel } from '../models/authors/author.model';

export const applicationMapper: Mapper = createMapper({
  strategyInitializer: classes(),
});

createMap(applicationMapper, Author, AuthorModel);
createMap(applicationMapper, AuthorModel, Author);
