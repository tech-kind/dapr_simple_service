# DaprSimpleService

* Daprのサービス呼び出しを利用したサンプルプログラム

## NumberRegistrationService

* Daprの実行コマンドで起動する

``` bash
cd .\NumberRegistrationService\
dapr run --app-id numberregistrationservice --app-port 6000 --dapr-http-port 3600 --dapr-grpc-port 60000 dotnet run
```

* \NumberRegistrationService\test.httpでAPIの挙動を確認する

``` json
// GET http://127.0.0.1:6000/number 実行時
HTTP/1.1 200 OK
Connection: close
Content-Type: application/json; charset=utf-8
Date: Fri, 05 Aug 2022 06:10:11 GMT
Server: Kestrel
Transfer-Encoding: chunked

25

// GET http://127.0.0.1:3600/v1.0/invoke/numberregistrationservice/method/number 実行時
HTTP/1.1 200 OK
Server: Kestrel
Date: Fri, 05 Aug 2022 06:12:19 GMT
Content-Type: application/json; charset=utf-8
Content-Length: 2
Traceparent: 00-4a5b66b2b2f5c301a607c35919ba2ad1-cdb0c88d9ac2b012-01
Connection: close

64
```

## NumberCollectionService

* NumberRegistrationServiceを実行している状態で起動すること

* Daprの実行コマンドで起動する

``` bash
cd .\NumberCollectionService
dapr run --app-id numbercollectionservice --app-port 6001 --dapr-http-port 3601 --dapr-grpc-port 60001 dotnet run
```

* \NumberCollectionService\test.httpでAPIの挙動を確認する

## zipkinでの監視

* configファイルを読み込んでNumberRegistrationServiceとNumberCollectionServiceを実行する

``` bash
# NumberRegistrationService
dapr run --app-id numberregistrationservice --app-port 6000 --dapr-http-port 3600 --dapr-grpc-port 60000 --config ../dapr/config/config.yaml dotnet run

# NumberCollectionService
dapr run --app-id numbercollectionservice --app-port 6001 --dapr-http-port 3601 --dapr-grpc-port 60001 --config ../dapr/config/config.yaml dotnet run
```

* http://localhost:9411/zipkin/ にアクセスしてAPIの監視が正常に行われているか確認する