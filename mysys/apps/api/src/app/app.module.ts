import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import {entities, AitCoreModule} from "@aureole/core";
import {controllers} from "@aureole/core";
import {dbConfig} from "@aureole/core";
import {services} from "@aureole/core";
import { Person } from './person/person.entity';
import { PersonController } from './person/person.controller';
import { PersonService } from './person/person.service';
import { Connection } from 'typeorm';
import { PersonModule } from './person/person.module';
@Module({
  imports: [
    PersonModule,
    AitCoreModule,
    TypeOrmModule.forRoot({
      ...dbConfig, entities: [
        ...entities,
        Person]
    }),
    TypeOrmModule.forFeature([...entities, Person])
  ],
  controllers: [...controllers],
  providers: [...services],
})
export class AppModule {}