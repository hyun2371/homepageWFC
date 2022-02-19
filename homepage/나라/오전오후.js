
var date=new Date();
var hours=date.getHours();
var minutes=date.getMinutes();
var noon;
var time;
if (hours>12&&hours<24){
    noon="오후";}
else{
    noon="오전";
}
if (hours>12){
   time=hours-12;
}
else{
    time=hours;
}

alert("지금은 "+noon+" "+time+"시 "+minutes+"분입니다."+"   ");
if (hours>=6 && hours<10){
    alert('<꿀물>을 마시기 좋은 시간입니다.\n꿀은 피로해소에 좋고 잠을 깨게 해줍니다.');
}
else if (hours>=10&& hours<14){
    alert('<토마토>를 먹기 좋은시간입니다.\n토마토는 혈압을 낮춰주기에 혈압이 높아지는 이 시간대에 적합합니다.\n식사 후 토마토를 섭취하면 소화가 잘됩니다. 생으로 먹지 말고 익혀서 먹으면 더 좋은 효과를 볼 수 있습니다.')
}
else if (hours>=14&&hours<18){
    alert('<우유>를 마시기 좋은 시간입니다.\n소화가 되고 나서 우유를 마시면 우유의 모든 영양분을 섭취할 수 있습니다.');
}
else if (hours>=18&&hours<22){
    alert('<당근>을 먹기 좋은 시간입니다. \n저녁에 볶아서 먹는 당근은 몸을 따뜻하게 해줍니다.\n당근으로 베타카로틴과 비타민, 키로틴 섬유소를 섭취할 수 있습니다.');
}
else{
   alert('<치즈>를 먹기 좋은 시간입니다.\n치즈에 있는 트립토판은 세로티닌을 분비시킵니다.\n세로티닌은 흥분성을 낮추어 뇌를 진정시키며 빨리 잠들 수 있도록 도와줍니다.');
}