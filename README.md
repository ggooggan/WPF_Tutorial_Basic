# dependency property

youtube: https://www.youtube.com/watch?v=ZsO29yvxpSM&t=620s </br>
dependency property 연습</br>


**Data Binding** UI 요소의 속성 값을 다른 UI 요소나 데이터 소스와 바인딩 할 수 있습니다.   
스타일과 템플릿 스타일과 템플릿을 사용하여 UI 요소의 모양과 동작을 쉽게 변경 할 수 있습니다.   
상속: 상위 요소에서 정의된 속성 값을 하위 요소에서 사용 할 수 있습니다.   

## Name="root" 설명
**Name="root"** 는 CalculateControl 컨트롤의 이름을 "root"로 지정하는 것을 의미합니다.   
Name 속성은 XAML에서 개체에 고유한 이름을 부여하는 데 사용됩니다.   
이름은 해당 컨트롤을 식별하고 다른 요소와 상호작용하는 데 사용될 수 있습니다.   
예를 들어 코드 뒷단에서 해당 컨트롤에 접근하거나 데이터 바인딩을 설정할 때 해당 이름을 사용할 수 있습니다.   
여기서 "root"는 컨트롤의 이름으로 선택된 것이며, 다른 이름을 선택할 수도 있습니다.   
일반적으로 "root"는 최상위 컨트롤이나 주 컨테이너 요소에 할당되는 이름으로 자주 사용됩니다.  
하지만 실제로는 원하는 이름을 사용할 수 있습니다.


usercontrol 사용하여 구성 </br>
propdb를 사용하여 dependency 문장을 자동 생성 </br>
usercontrol의 Name "root"를 지정하여 parameter 획득 </br>

## 예시 1
```c#
public static readonly DependencyProperty Value1Property = </br>
            DependencyProperty.Register("Value1", typeof(decimal), typeof(CalculateControl), new PropertyMetadata(0m, OnValueChanged, CoerceLimitValue));
```
new PropertyMetadata(0m, OnValueChanged, CoerceLimitValue));</br>
0m : 초기 값 </br>
onValueChanged: 변경되었을 경우 수행 되는 함수 </br>
CoerceLimitValue : 제한 되는 함수 </br>

## 예시 2
```c#
 <local:CalculateControl Value1="{Binding Value11}" Value2="{Binding Value2}" Operator="{Binding Operator}" DesignMode="WHITE"/> </br>
```
Value1: Usercontrol에서 만든 변수 </br>
Value11: mvvm에서 만든 MainViewModel 변수 </br>
