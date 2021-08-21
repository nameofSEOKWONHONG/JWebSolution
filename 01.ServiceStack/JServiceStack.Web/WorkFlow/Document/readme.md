[workflow 설명]
1. workflow란?
- workflow는 서비스와 레파지토리, 벨리데이터 등을 묶어서 실행할 수 있도록 하는 라이브러리.
2. 각 역활은?
- Validators : Request Entity나 dto등의 데이터 검사를 진행 하는 역활을 한다.
  - Null Check
  - String Check
  - Regex Check
  - 등등...
- Executors : 실행하고자 하는 서비스, 레파지토리등을 등록하여 호출하도록 한다.
  - database crud 구현
  - 메인 비즈니스 구현
  - 등등..
3. Executor와 Executors는?
  - Executor는 하나의 Executor를 실행하고자 하는 경우
  - Executors는 여러개의 Executor를 하나의 트랜젝션에 묶고자 하는 경우에 사용한다.
4. 기본 등록
   - 프로젝트 > Workflow > Controller명 > Action 명 으로 동작하게 된다.
   - Controller와 엮이지 않는 workflow는 workflow-manger를 이용하여 수동으로 호출한다.
5. 장단점
   - 장점 : 
     - 독립적 실행 모듈 구성을 할 수 있다.
     - 이미 구성된 모듈을 여러 형태로 재사용 할 수 있다.
   - 단점 : 
     - RequesDataContext의 데이터 구성이 Dictionary형태로 사용되므로 각 모듈이 독립적으로 구성되어 있어도 사용하고자 하는 모듈의 구성형태를 알지 못한다면 오류를 피할 수 없다.
     - 모듈의 독립성을 획득하는 대신에 각 모듈의 데이터 가공형태를 반드시 알아야 한다.
     - 따라서 해당 모듈을 개발할 경우 문서화되어 있지 않다면 -즉, 세부적인 주석 또는 독립적 문서가 필요함.- 개발이 상당히 고통스러울 수 있다.
     - 또한 개발자 커뮤니케이션 비용이 상당히 발생할 여지가 있다.
     - 결국 독립적 개발이 아닌 형태로 봐야 할 것이고 Swagger같은 툴을 사용할 수 없으므로 난해한 것은 마찬가지임.




