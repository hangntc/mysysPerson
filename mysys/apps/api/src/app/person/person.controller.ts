import { Controller, Get, Post, Body, Put, Param, Delete, RequestMapping, HttpException, HttpStatus, UsePipes, ValidationPipe } from "@nestjs/common";
import { PersonService } from './person.service';
import { Person } from './person.entity';
import { UpdateResult } from 'typeorm';
import { CreateGroupDto } from './person.dto';
import { pseudoRandomBytes } from 'crypto';

@Controller('person')
export class PersonController{
    constructor(
        private readonly psService :PersonService,
    ){}

    @Post('get/many')
    async getAllPS(@Body() body:any[]): Promise<any[]> {
       return await this.psService.getAll(body);
    }

    @Post('get/one')
    async getAllPSOne(@Body() body:any) {
      return await this.psService.getOne(body);
    }

    @Post('post')
    @UsePipes(new ValidationPipe())
    async CreatePS(@Body() dto: CreateGroupDto): Promise<any> {
      const newGroup = Object.assign(dto);
      const result= await this.psService.Add(newGroup);
     if(result===true)
     {
      throw new HttpException({
        status: HttpStatus.OK,
        message:'Post Successful!'},200);
     }
     else{
       throw new HttpException({
        status: HttpStatus.INTERNAL_SERVER_ERROR,
        message:'Error!'},500);
     }
    }

    @Post('put')
    @UsePipes(new ValidationPipe())
    async UpdateResult(@Body()dto: CreateGroupDto): Promise<any> 
    {
      const newGroup = Object.assign(dto);
      const result = await this.psService.Update(newGroup);
        console.log(result);
        if(result === true) {
          throw new HttpException({
            status: HttpStatus.OK,
            message: 'Put Successful!'}, 200);
        } 
        else{
          throw new HttpException({
           status: HttpStatus.INTERNAL_SERVER_ERROR,
           message:'Error!'},500);
        }   
    }

    @Post('delete/one')
    async deletePS(@Body() body :any): Promise<any> {
      await this.psService.DeleteOne(body);
    }
    @Post('delete/many')
    async deleteAll(@Body() body:any[]): Promise<any> {
      this.psService.deleteMany(body);
      }
}
