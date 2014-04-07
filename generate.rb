colors = [
    [:Green, 6],
    [:Purple, 4],
    [:Red, 6],
    [:Yellow, 4],
    [:Blue, 1],
    [:Orange, 1]
]

colors.each do |color|
    (1..color[1]).each do |i|
        puts "public bool #{color[0]}#{i}Checked { get; set; }\npublic string #{color[0]}#{i}Desc { get; set; }\n\n"
    end
end