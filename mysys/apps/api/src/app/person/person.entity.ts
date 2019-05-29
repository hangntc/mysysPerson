import { Column, Entity, PrimaryColumn} from 'typeorm';

@Entity('biz_m_person')

export class Person {
@PrimaryColumn('character varying',{length: 20 })
company: string;

@PrimaryColumn('character varying', {length: 20})
department_code: string;

@PrimaryColumn('character varying', {length: 20})
group_code: string;

@PrimaryColumn('character varying', {length: 20})
emp_id: string;

@Column('boolean')
active_flag: boolean;

@Column('character varying', {nullable: true})
position: string;

@Column('character varying', { nullable: true })
rank: string;

@Column('integer')
change_count: number;

@Column('character varying', {length: 20})
create_emp_id: string;

@Column('timestamp without time zone')
create_datetime: string;

@Column('character varying', {length: 20})
change_emp_id: string;

@Column('timestamp without time zone')
change_datetime: string;

@Column('character',{length:1})
data_flag: string;
}
