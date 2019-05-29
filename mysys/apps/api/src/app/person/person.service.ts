import { Injectable, NotFoundException, BadRequestException, HttpStatus, HttpException } from "@nestjs/common";
import { Repository, UpdateResult, DeleteResult } from "typeorm";
import { InjectRepository } from '@nestjs/typeorm';
import { Person } from '../person/person.entity';
import { CreateGroupDto } from './person.dto';
import { MESSAGES } from '@nestjs/core/constants';


@Injectable()
export class PersonService{
    constructor(
        @InjectRepository(Person)
        private  personRepository: Repository<Person>,){}

    async getAll(context: any){
      const params = new Object();
      let list = [];

          if (context.active_flag !== undefined) {
        params[ 'active_flag'] = context.active_flag;
      }
      if (context.position !== undefined) {
        params['position'] = context.position;
      }
      if (context.rank !== undefined) {
        params['rank'] = context.rank;
      }
      const result=await this.personRepository.find({
        company: context.company,   
        ...params
      });

      list = [...result];
console.log(list);

      // search form to department_code
      if(context.department_codeFrom !==undefined){
          const index =list.findIndex((element: any)=>{
            return element.department_code===context.department_codeFrom;
          });
          console.log(index,list.length)
      if(index>=0)
          {
            list=list.slice(index,list.length);
          }
      }

      if(context.department_codeTo !==undefined)
      {
        const index =list.findIndex((element:any)=>{
          return element.department_code===context.department_codeTo;
        });
        if(index>0){
          list=list.slice(0,index+1);
        }
      }

       // search form to group_code
       if (context.group_codeFrom !== undefined) {
        const index = list.findIndex((element: any) => {
          return element.group_code === context.group_codeFrom;
        });
  
        if (index >= 0) {
          list = list.slice(index);
        }
      }
  
      if (context.group_codeTo !== undefined) {
        const index = list.findIndex((element: any) => {
          return element.group_code === context.group_codeTo;
        });
  
        if (index >= 0) {
          list = list.slice(0, index + 1);
        }
      }

       // search form to emp_id
       if (context.emp_idFrom !== undefined) {
        const index = list.findIndex((element: any) => {
          return element.emp_id === context.emp_idFrom;
        });
  
        if (index >= 0) {
          list = list.slice(0, index + 1);
        }
      }
  
      if (context.emp_idTo !== undefined) {
        const index = list.findIndex((element: any) => {
          return element.emp_id === context.emp_idTo;
        });
  
        if (index >= 0) {
          list = list.slice(0, index + 1);
        }
      }


      // search form to change_count
      if (context.change_countFrom !== undefined) {
        const index = list.findIndex((element: any) => {
          return element.change_count === context.change_countFrom;
        });
  
        if (index >= 0) {
          list = list.slice(0, index + 1);
        }
      }
  
      if (context.change_countTo !== undefined) {
        const index = list.findIndex((element: any) => {
          return element.change_count === context.change_countTo;
        });
  
        if (index >= 0) {
          list = list.slice(0, index + 1);
        }
      }

      // search form to create_emp_id
      if (context.create_emp_idFrom !== undefined) {
        const index = list.findIndex((element: any) => {
          return element.create_emp_id === context.create_emp_idFrom;
        });
  
        if (index >= 0) {
          list = list.slice(0, index + 1);
        }
      }
  
      if (context.create_emp_idTo !== undefined) {
        const index = list.findIndex((element: any) => {
          return element.create_emp_id === context.create_emp_idTo;
        });
  
        if (index >= 0) {
          list = list.slice(0, index + 1);
        }
      }
      
       
      // search form to create_datetime
      
      if (context.create_datetimeFrom !== undefined)
      {
        const dateFrom = new Date(context.create_datetimeFrom);
        const listSort = list.sort((a,b) =>(a.create_datetime - b.create_datetime));

        const indexList = listSort.findIndex((element: any) => {
        return new Date(element.create_datetime+"+0000").toJSON() >= new Date(context.create_datetimeFrom).toJSON();});
        if( new Date(listSort[listSort.length-1].create_datetime + "+0000").toJSON() < dateFrom.toJSON() ){
          list =[]
        }
        if (indexList >= 0) {
          list = listSort.slice(indexList,listSort.length);
        }
      }
  
      if (context.create_datetimeTo !== undefined) {
        const dateTo = new Date(context.create_datetimeTo);
        dateTo.setMinutes(dateTo.getMinutes() + 1439)
       const  listSort = list.sort((a,b) =>(a.create_datetime - b.create_datetime));
        const indexList = listSort.findIndex((element: any) => {
          return (new Date (element.create_datetime+"+0000").toJSON() < dateTo.toJSON());
        });
  
      if (indexList >= 0) {
          list = listSort.slice(indexList,listSort.length);
        }
      }

      // search form to change_emp_id
      if (context.change_emp_idFrom !== undefined) {
        const index = list.findIndex((element: any) => {
          return element.change_emp_id === context.change_emp_idFrom;
        });
  
        if (index >= 0) {
          list = list.slice(0, index + 1);
        }
      }
  
      if (context.change_emp_idTo !== undefined) {
        const index = list.findIndex((element: any) => {
          return element.change_emp_id === context.change_emp_idTo;
        });
  
        if (index >= 0) {
          list = list.slice(0, index + 1);
        }
      }
  

      // search form to change_datetime
      if (context.change_datetimeFrom !== undefined) {
        //sort sm-lg
        const dateFrom = new Date(context.change_datetimeFrom);
        const listSort = list.sort((a,b) =>(a.change_datetime - b.change_datetime));
        //find(indexFrom)
        const indexFrom = listSort.findIndex((element: any) => {
          return new Date(element.change_datetime+"+0000").toJSON() >= new Date (context.change_datetimeFrom).toJSON();
        });
        //date trong SortList < dateFrom = List[];
        if(new Date(listSort[listSort.length-1].change_datetime+"+0000").toJSON() < dateFrom.toJSON() ){
          list=[]
        }
  
        if (indexFrom >= 0) {
          list = listSort.slice( indexFrom,listSort.length);
        }
      }
  
      if (context.change_datetimeTo !== undefined) {
        const dateTo = new Date(context.change_datetimeTo);
        dateTo.setMinutes(dateTo.getMinutes()+1439)

        const SortList=list.sort((a,b)=>b.change_datetime - a.change_datetime);
        const indexTo = list.findIndex((element: any) => {
          return new Date( element.change_datetime+"+0000").toJSON() < dateTo.toJSON();
        });
  
        if (indexTo >= 0) {
          list = SortList.slice(indexTo,SortList.length);
        }
        else{
          list=[]
        }
      }
     
      for(const i of list)
      {
        i.create_datetime = new Date( i.create_datetime+"+0000");
        i.change_datetime = new Date( i.change_datetime+"+0000");
      }

      return list;
    }

    async getOne(context:any){
      return await this.personRepository.findOne({
        company:context.company,
        department_code:context.department_code,
        group_code:context.group_code,
        emp_id:context.emp_id
      })
    }

    async Add( context:any){
       if(context.emp_id !==''){
         const result = await this.personRepository.find({
          company:context.company,
          department_code:context.department_code,
          group_code:context.group_code,
          emp_id:context.emp_id
         });
         if(result){
          await this.personRepository.save(context)
          return true;
         }
        return false;
       }
      return false;
      }


      async Update(context: any){
        if(context.emp_id!==''){
          const result=await this.personRepository.find({
          company:context.company,
          department_code:context.department_code,
          group_code:context.group_code
          });
          if(result){
            context.change_count++;
            const key =({"company" : context.company, "department_code":context.department_code, "group_code":context.group_code});
            await this.personRepository.update(key,context);
            return true;
           }
          return false;
         }
        return false;
        }
       


      async DeleteOne(context: any){
          const result=await this.personRepository.find({
            company: context.company,
            department_code:context.department_code,
            group_code: context.group_code,
            emp_id: context.emp_id
          });
          if(result)
          {
           return await this.personRepository.delete({
              company: context.company,
              department_code:context.department_code,
              group_code: context.group_code,
              emp_id: context.emp_id
            });
            }            
        }


        async deleteMany(context: any[]) 
        {
          const result = await this.personRepository.delete(context);
          if (result.affected > 0) {
            return true;
          }
          return false;
        }
}
