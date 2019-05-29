import {  IsOptional ,IsDateString ,IsNumber ,IsBoolean, MaxLength, IsNotEmpty, IsEmail, IsString, Length } from 'class-validator';
export class CreateGroupDto {

@MaxLength(20,{message:"Company is not valid"})
@IsNotEmpty({message:"Company is required"}) company:string;

@IsOptional()
@MaxLength(20,{message:"department_code is not valid"})
@IsString({message:"department_code must be a string"}) department_code: string;

@MaxLength(20,{message:"group_code is not valid"})
@IsNotEmpty({message:"group_code is required"}) group_code:string;

@MaxLength(20,{message:"emp_id is not valid"})
@IsNotEmpty({message:"emp_id is required"}) emp_id: string;

@IsBoolean()
@IsNotEmpty({message:"active_flag is required"}) active_flag: boolean;


@IsOptional()
@IsString({message:"position must be a string"}) position: string;

@IsOptional()
@IsString({message:"rank must be a string"}) rank: string;

@IsNumber()
@IsNotEmpty({message:"change_count is required"}) change_count: number;

@IsString({message:"create_emp_id must be a string"}) 
@MaxLength(20,{message:"create_emp_id is not valid"})
@IsNotEmpty({message:"create_emp_id is required"}) create_emp_id: string;

@IsDateString()
@IsNotEmpty({message:"create_datetime is required"}) create_datetime: string;

@IsString({message:"change_emp_id must be a string"}) 
@MaxLength(20,{message:"change_emp_id is not valid"})
@IsNotEmpty({message:"change_emp_id is required"}) change_emp_id: string;

@IsDateString()
@IsNotEmpty({message:"change_datetime is required"}) change_datetime: string;

@IsNotEmpty({message:"data_flag is required"})
@Length(1) data_flag: string;
}