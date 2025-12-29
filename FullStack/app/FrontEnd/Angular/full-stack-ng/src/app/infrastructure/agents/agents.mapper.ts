import { createMap, createMapper, Mapper } from '@automapper/core';
import { classes } from '@automapper/classes';
import { Author } from '../../business/domain/entities/Auhtor.entity';
import { AuthorResponse } from './authors/dtos/author.response';
import { AuthorForUpdateRequest } from './authors/dtos/author-for-update.request';
import { AuthorForCreationRequest } from './authors/dtos/author-for-creation.request';

export const agentsMapper: Mapper = createMapper({
  strategyInitializer: classes(),
});

createMap(agentsMapper, AuthorResponse, Author);
createMap(agentsMapper, Author, AuthorForUpdateRequest);
createMap(agentsMapper, Author, AuthorForCreationRequest);
