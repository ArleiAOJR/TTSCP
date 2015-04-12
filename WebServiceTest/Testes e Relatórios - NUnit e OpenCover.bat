echo "Colocar este bat no diretorio \bin onde o dll é gerado"

"C:\Users\Arlei\Desktop\TTSCP\WebServiceTest\WebServiceTest\packages\OpenCover.4.5.3723\OpenCover.Console.exe" -target:"C:\Users\Arlei\Desktop\TTSCP\WebServiceTest\WebServiceTest\packages\NUnit.Runners.2.6.4\tools\nunit-console.exe" -targetargs:"/nologo WebServiceTest.dll /noshadow" -filter:"+[WebServiceTest]WebServiceTest*" -excludebyattribute:"System.CodeDom.Compiler.GeneratedCodeAttribute" -register:user -output:"_CodeCoverageResult.xml"

"C:\Users\Arlei\Desktop\TTSCP\WebServiceTest\WebServiceTest\packages\ReportGenerator.2.1.4.0\ReportGenerator.exe" "-reports:_CodeCoverageResult.xml" "-targetdir:_CodeCoverageReport"

pause