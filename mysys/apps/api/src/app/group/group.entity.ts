import { Column, Entity, PrimaryColumn} from 'typeorm';

@Entity('group')
export class Group {
  @PrimaryColumn()
  company: any;

  @Column('text')
  lang: any;

  @Column('text')
  code: any;

  @Column('text')
  name: any;

  @Column('boolean')
  active_flag: any;

  @Column('text')
  department_code: any;

  @Column('text')
  address1: any;

  @Column('text')
  address2: any;

  @Column('text')
  tel1: any;

  @Column('text')
  tel2: any;

  @Column('text')
  email: any;

  @Column('number')
  change_count: any;

  @Column('text')
  create_emp_id: any;

  @Column('date')
  create_datetime: any;

  @Column('text')
  change_emp_id: any;

  @Column('text')
  change_datetime: any;

  @Column('text')
  data_flag: any;
}