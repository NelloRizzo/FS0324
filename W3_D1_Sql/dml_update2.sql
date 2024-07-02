update Operai
set
	Salario = Salario + salario * .1
where
	LivelloLavorativo < 10 and FigliACarico > 1